+++
title = "The Beauty of C++ Templates"
date = 2011-04-01
[taxonomies]
tags = ["C++"]
+++

Every so often, I'll get a random C++ question from a friend or colleague. Most
of the time the answers are trivial, at least for someone who has a history with
the language. Other questions make me stop and ponder, searching for the best
"C++" way to do something. Yesterday, the question was simple and the solution
turned out to be equally simple, but getting to the solution made me stop and
appreciate some of the cool things one can do with C++ templates.

# The Problem

The problem was simple. Suppose you have a C++ template class/struct that is
parameterized by a single type, e.g.

```c++
   template<typename T>
   class my_data {
     // ...
   private:
     T element_;
   };
```

# The Solution

Now, the question is, "how do I write a method for this class/struct that maps
the type of T to an enumeration value?" For context, the real problem involved
mapping T to an MPI data type, e.g. (float -> MPI\_FLOAT), (double ->
MPI\_DOUBLE), etc..

The first thought for anyone familiar with containers may be to explicitly
generate a map, e.g. std::map in this case, to hold all possible mappings from
the C++ type (via typeid()) to the MPI type (really just an integer). Such a
solution is certainly valid and may be the best way to approach the problem in
another language such as C# or Java. After pondering the "C++" solution to the
problem for a few minutes, my colleague and I came up with a fairly elegant
solution involving templates. Or, at least I found it quite elegant.

```c++
   /**
    * This struct wrappers the MPI data type value for the given C++ type.
    *
    * Any valid MPI data type value must have a corresponding explicit template
    * instantiation below.
    */
   template<typename T>
   struct mpi_type_wrapper {
     int mpi_type;
     mpi_type_wrapper();
   };

   // Explicit instantiation for `float'
   template <>
   mpi_type_wrapper::mpi_type_wrapper()
   : mpi_type(MPI_FLOAT) {}

   // Explicit instantiation for `double'
   template <>
   mpi_type_wrapper::mpi_type_wrapper()
   : mpi_type(MPI_DOUBLE) {}
```

The mpi\_type\_wrapper struct is a convenient way to convert an arbitrary C++
type to an equivalent MPI type. All one has to do is declare a local variable of
type mpi\_type\_wrapper<T> (with appropriate T) and read the value of its
mpi\_type field. Of course, none of this is specific to MPI in any way. The only
requirement is that an explicit instantiation of the constructor must be
provided for any C++ types that are to be converted.

# Why This Solution?

This solution strikes me as elegant for two reasons. First, it is a solution
that would be difficult, if not impossible, to express in many other languages.
Second, and most interesting to me, there is *no* run-time overhead associated
with this solution. You can even compile this with RTTI turned off. Any
reasonable compiler automatically inlines the appropriate constructor, then
constant propagation replaces any uses of the mpi\_type field with the
appropriate MPI\_\* enumeration value. There is no memory overhead associated
with explicitly keeping a map at run-time, nor any time overhead of performing a
map look-up. The final code just uses the constant value! If you do not believe
me, check out this example:

```c++
   /**
    * Some template class that needs to know the MPI_DataType value for its
    * template parameter type.
    */
   template<typename T>
   struct some_type {
     void printType() {
       mpi_type_wrapper<T> wrap;

       printf("My Type: %d", wrap.mpi_type);
     };
   };

   int main() {
     some_type<float> floatClass;
     some_type<double> doubleClass;

     floatClass.printType();
     doubleClass.printType();

     return 0;
   }
```

And the generated code?

```nasm
   _main:
     pushq %rbx
     leaq L_.str(%rip), %rbx
     movq %rbx, %rdi
     xorl %esi, %esi
     xorb %al, %al
     callq _printf
     movl $1, %esi
     movq %rbx, %rdi
     xorb %al, %al
     callq _printf
     xorl %eax, %eax
     popq %rbx
     ret
```

# Conclusion

While this example is probably trivial for most experienced C++ programmers out
there, including myself, I always find myself stopping and appreciating such
solutions. In this case, C++ templates provide such an elegant and efficient
solution that I cannot help feeling giddy.
