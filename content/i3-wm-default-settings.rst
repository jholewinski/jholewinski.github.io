i3 WM: Default Workspace Settings
#########################################
:date: 2013-07-11 23:00
:author: Justin Holewinski
:tags: Linux, i3
:slug: i3-wm-default-workspace-settings
:category: General


I've been playing around with the i3 window manager a lot lately, and I have
to say I enjoy it very much!  But one default setting  that tripped me up (as
set by ``i3-config-wizard``) was the key bindings for workspace switching:

.. code-block:: text

  bindsym $mod+1 workspace 1
  bindsym $mod+2 workspace 2
  bindsym $mod+3 workspace 3
  # ...

This works well until you start naming your workspaces. With these bindings,
you will switch to workspace *name* "1", not *number* "1".  So if you rename
workspace 1 to "1: Firefox" and press Mod5+1, you'll end up opening a new
workspace instead of going to the "1: Firefox" workspace.  Not very intuitive!
Luckily, we can easily get the desired behavior with a slight tweak to the
config file:

.. code-block:: text

  bindsym $mod+1 workspace number 1
  bindsym $mod+2 workspace number 2
  bindsym $mod+3 workspace number 3
  # ...

