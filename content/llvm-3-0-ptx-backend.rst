LLVM 3.0: PTX Backend
#####################
:date: 2011-12-02 11:17
:author: Justin Holewinski
:tags: GPU, LLVM, OpenCL
:slug: llvm-3-0-ptx-backend
:category: Programming

**NOTE**: The information is this article only applies to LLVM 3.0 and
3.1. As of LLVM 3.2, the PTX back-end has been replaced with the NVPTX
back-end.

With the release of LLVM 3.0, the PTX back-end is now in a fairly usable
state.  It even integrates with the Clang OpenCL front-end to produce
correct PTX code usable by the nVidia OpenCL run-time.  However, please
note that the back-end is still experimental and there are unimplemented
features.  As always, please post any questions to the llvm-dev mailing
list.

In this post, I aim to give a quick overview of how to use the back-end
to compile OpenCL kernels.

As an example, consider the following matrix multiplication routine
written in OpenCL:

.. code-block:: c++
   :linenos:

   #define BLOCK_SIZE 16

   __kernel
   void matmul(__global float* A, __global float* B, __global float* C) {

     __local float scratchA[BLOCK_SIZE][BLOCK_SIZE];
     __local float scratchB[BLOCK_SIZE][BLOCK_SIZE];

     int globalX = get_global_id(0);
     int globalY = get_global_id(1);
     int size = get_global_size(0);
     int k;
     float sum = 0.0f;
     int numBlocks = size / BLOCK_SIZE;
     int b;

     int tidX = get_local_id(0);
     int tidY = get_local_id(1);

     for(b = 0; b < numBlocks; ++b) {
       // Populate a cache for A/B
       int x;
       int y;

       x = b * BLOCK_SIZE + tidX;
       y = globalY;

       scratchA[tidY][tidX] = A[y * size + x];

       x = globalX;
       y = b * BLOCK_SIZE + tidY;

       scratchB[tidY][tidX] = B[y * size + x];

       barrier(CLK_LOCAL_MEM_FENCE);

       for(k = 0; k < BLOCK_SIZE; ++k) {
         float myA;
         float myB;

         myA = scratchA[tidY][k];
         myB = scratchB[k][tidX];

         sum += myA * myB;
       }

       barrier(CLK_LOCAL_MEM_FENCE);
     }

     C[globalY * size + globalX] = sum;
   }


We can use the `libclc`_ library, written by Peter Collingbourne, to
provide the OpenCL built-in functions for Clang.  This library will map
OpenCL built-in functions to target-specific functions in the LLVM IR
that the PTX back-end knows how to handle.  If ``$LIBCLC`` points to the
download of libclc, then you can invoke Clang with:

::

   clang -ccc-host-triple ptx32
     -Xclang -target-feature -Xclang +ptx23
     -Xclang -target-feature -Xclang +sm20
     -I$LIBCLC/include/generic -I$LIBCLC/include/ptx
     -include clc/clc.h -Dcl_clang_storage_class_specifiers
     -O3 matmul_kernel.cl -S -o matmul_kernel.ptx


The options can be a bit verbose at the moment, but practically all of
them can be placed in a wrapper script.  Clang will compile the kernel
and emit the generated PTX code to ``matmul_kernel.ptx``.  This code can
then be loaded as an OpenCL binary kernel using the nVidia OpenCL SDK,
using the ``clCreateProgramWithBinary`` function.  As an added bonus,
the performance is about the same as if the kernel was compiled using
the nVidia OpenCL compiler!

.. _libclc: http://www.pcc.me.uk/~peter/libclc
