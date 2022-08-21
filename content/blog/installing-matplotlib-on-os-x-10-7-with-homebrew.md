+++
title = "Installing Matplotlib on OS X 10.7 with Homebrew"
date = 2011-07-21
[taxonomies]
tags = ["Homebrew", "Mac OS X", "Matplotlib"]
+++

[edit: It looks like things have changed a bit since the release of 10.7, so
your mileage may vary with this method. This was written when 10.7 was brand new
and most software was not yet updated for it.]

For those of you that do not know, `Matplotlib` is an excellent Python plotting
library that allows you to create professional-quality plots for inclusion on
web pages, Latex documents, Beamer presentations, Keynote presentations, and any
other software that can import SVG, EPS, PNG, or virtually any graphic format.

However, getting matplotlib installed on Mac OS X 10.7 can be a bit tricky,
especially if you are using `Homebrew` as your "package manager." First off,
Homebrew does not have packages for matplotlib, as well as some of its
dependencies. Additionally, the current Matplotlib release version (1.0.1 as of
this post) does not compile out-of-the-box against libpng 1.5, which is included
in the X11 distribution shipped with Mac OS X 10.7.

For previous versions of Mac OS X (10.6, 10.5), the usual way to install
matplotlib was to install python, pkg-config, and gfortran with Homebrew, then
install numpy and matplotlib through pip, ala:

```
   $ brew install python
   $ brew install gfortran
   $ brew install pkg-config
   $ easy_install pip
   $ pip install numpy
   $ pip install matplotlib
```

Unfortunately, as previously mentioned, all is not so easy in the world of Mac
OS X 10.7, and the difficulty lies with libpng 1.5, installed with Mac OS X
10.7's version of X11. Briefly put, Matplotlib 1.0.1 is not compatible with
libpng 1.5 due to a change in the API. Fortunately, the fix is already applied
up-stream and will probably be a part of Matplotlib 1.0.2, or 1.1.0, or whatever
the next released version is.

Until the next release, the Matplotlib sources in Git can be used. Instead of
pulling the sources from the Matplotlib SourceForge site, you need to pull them
from the Matplotlib GitHub site. I'm not sure if this GitHub site is "official,"
but is looks to be.

All that is needed is to build Matplotlib from source instead of using pip, so
the installation procedure is now:

```
   $ brew install python
   $ brew install gfortran
   $ brew install pkg-config
   $ easy_install pip
   $ pip install numpy
   $ cd $HOME
   $ git clone https://github.com/matplotlib/matplotlib.git
   $ cd matplotlib
   $ python setup.py build
   $ python setup.py install
```

And now you're good to go! Hopefully this will become much easier with the next
official release of Matplotlib.
