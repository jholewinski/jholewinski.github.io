+++
title = "Direct3d 11 With Qt 4"
date = 2012-02-16
[taxonomies]
tags = ["Direct3D", "Qt", "Windows", "C++"]
+++

(If you're in a hurry, the full source can be found on my [Bitbucket](https://bitbucket.org/jholewinski/qt4-d3d11) account)

When it comes to GUI frameworks for C++, it's very hard to beat Qt.
 It's modular, easy to use, and available on practically any desktop
system (and even a few mobile systems).  The MOC'ing can get a bit
annoying, but IDE and command-line support is very mature at this point.
 However, only OpenGL is supported currently for real-time 3D rendering.
If you want to render to a Qt widget from a Direct3D 11 device, you end
up having to do a lot of setup yourself.

Unfortunately, there is not a lot of information out on the internet
about setting up Direct3D to play nice with Qt.  Most of the information
is either out-dated, or only applies to Direct3D 9.  Lately, I've been
playing around with this and I want to share my method for combining
Direct3D 11 and Qt.

![Screenshot](/images/qtd3d11-screen1.png)

# Creating a Widget

To start, we define a new widget sub-class specifically for Direct3D 11
rendering. On the Qt side, the key to eliminating flickering or UI
artifacts is the `paintEngine()` method.  We need a way to tell Qt
that we want complete control over drawing for our widget, so we can
override `paintEngine()` in our widget definition:

```c++
   class D3DRenderWidget : public QWidget {
     Q_OBJECT
     Q_DISABLE_COPY(D3DRenderWidget)
   public:
     D3DRenderWidget(QWidget* parent = NULL);
     virtual ~D3DRenderWidget();
     virtual QPaintEngine* paintEngine() const { return NULL; }
   protected:
     virtual void resizeEvent(QResizeEvent* evt);
     virtual void paintEvent(QPaintEvent* evt);
   };
```

(Note that for ease of viewing, all of the fields have been removed from
this code snippet)

We also need to set a few attributes on our widget, as shown in the
constructor:

```c++
   D3DRenderWidget::D3DRenderWidget(QWidget* parent)
     : QWidget(parent) {
     setAttribute(Qt::WA_PaintOnScreen, true);
     setAttribute(Qt::WA_NativeWindow, true);

     // Create Device
     createDevice();
   }
```


First, we tell Qt that we do not want it to do any draw buffering for
us. Second, we require a native window handle for our widget. Otherwise,
Qt may re-use the same native handle for multiple widgets and cause
problems for our Direct3D rendering. You may have also noticed the
`createDevice()` method call; this will be explained in a bit.

 

# Creating the Direct3D 11 Device

Now that we have a basic widget that can support Direct3D rendering, we
can initialize the Direct3D 11 device we want. This procedure is mostly
identical to setting up Direct3D in a raw window. The only difference is
that we must use the `width()`, `height()`, and `winId()` methods
to return the widget size and native window handle, respectively:

```c++
   swapChainDesc_.BufferCount = 1;
   swapChainDesc_.BufferDesc.Width = width();
   swapChainDesc_.BufferDesc.Height = height();
   swapChainDesc_.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
   swapChainDesc_.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
   swapChainDesc_.SampleDesc.Count = 4;
   swapChainDesc_.SampleDesc.Quality = 0;
   swapChainDesc_.Windowed = true;
   swapChainDesc_.OutputWindow = winId();
   swapChainDesc_.BufferDesc.RefreshRate.Numerator = 60;
   swapChainDesc_.BufferDesc.RefreshRate.Denominator = 1;
```

Everything else remains the same... pretty easy, huh? :)

 

# Handling Paint Events

Remember the `paintEvent` override from the widget class definition?
We can simply implement it with a call to some rendering function:

```c++
   void D3DRenderWidget::paintEvent(QPaintEvent* evt) {
     render();
   }
```


Here, `render()` is just some arbitrary method that uses the Direct3D
11 device to render something to the primary swap chain.

 

# Handling Resize Events

Resize events are perhaps the hardest events to handle when integrating
Direct3D 11 and Qt. To resize our swap chain, we need to release all
device-allocated resources, and reallocate them. The procedure I follow
is:

```c++
   void D3DRenderWidget::resizeEvent(QResizeEvent* evt) {
     releaseBuffers();
     swapChain_->ResizeBuffers(1, width(), height(), swapChainDesc_.BufferDesc.Format, 0);
     swapChain_->GetDesc(&swapChainDesc_);
     viewport_.Width = width();
     viewport_.Height = height();
     createBuffers();
   }
```

We start by releasing all of the buffers we had allocated (vertex
buffers, index buffers, shaders, textures, etc.). We then issue a resize
request to the swap chain, resize our rendering viewport, and then
recreate all of our needed buffers. In this snippet,
`releaseBuffers()` will call `Release()` on all buffers, and
`createBuffers()` will create all of the needed resources (again).

It would probably be easier to just allow the swap chain to grow and
just adjust the viewport if the widget shrinks, but this method shows
how to keep the swap chain the exact same size as the widget.

 

# Conclusion

At this point, you should have a functional Direct3D 11 rendering
context for a Qt widget. For brevity, I have omitted most of the
Direct3D initialization code (this can be found in many places on the
web).

If you want to check out the complete sample program, it is located on
my [BitBucket](https://bitbucket.org/jholewinski/qt4-d3d11) account.
To build it, you need a relatively recent Qt
release, the DirectX SDK, and the Qt Visual Studio Add-in.


