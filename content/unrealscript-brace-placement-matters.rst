UnrealScript: Brace Placement Matters!
######################################
:date: 2012-03-17 00:22
:author: Justin Holewinski
:tags: Unreal
:slug: unrealscript-brace-placement-matters
:category: Programming

I was playing around with the Unreal Development Kit this evening, and
discovered a rather interesting quirk in the handling of braces within
UnrealScript.  All of the sample code I read use a syntax style that
places opening braces on the following line:

.. code-block:: c++

    event PostBeginPlay()
    {
      // Do something
    }

However, my typical style places the opening brace on the current line:

.. code-block:: c++

    event PostBeginPlay() {
      // Do something
    }

Unfortunately, this does not seem to work for ``defaultproperties``
blocks. If you place the brace on the same line, the compiler will not
give you any warnings or errors, but the entire ``defaultproperties``
block is just ignored!

So this code works:

.. code-block:: text

    defaultproperties
    {
      PlayerControllerClass=class'MyPlayerController'
    }

while the following code compiles but silently just ignores all of the
contained settings:

.. code-block:: text

    defaultproperties {
      PlayerControllerClass=class'MyPlayerController'
    }

I was banging my head on the wall for at least an hour figuring this one
out!

I hope this can help prevent someone else from repeating my mistake.
