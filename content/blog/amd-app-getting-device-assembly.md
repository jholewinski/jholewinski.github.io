+++
title = "AMD APP: Getting Device Assembly"
date = 2012-02-09
slug = "amd-app-getting-device-assembly"
[taxonomies]
tags = ["GPU", "OpenCL", "AMD"]
+++

Sometimes it is useful to look at the intermediate and assembly code for GPU
programs. This can lead to some interesting performance insights, especially for
compiler writers. Unfortunately, the AMD APP SDK is a bit limited on Linux, and
the AMD APP KernelAnalyzer, which conveniently dumps the AMDIL and Device ISA
for an OpenCL kernel, is not available on Linux. However, digging through the
AMD APP OpenCL Programming Guide, one finds an environment variable that can be
used for the same purpose: `GPU_DUMP_DEVICE_KERNEL`.

According to the programming guide, this environment variable can take one of
three values:

<table columns="3">
<tr><td>1</td><td>Save intermediate IL files in local directory.</td></tr>
<tr><td>2</td><td>Disassemble ISA file and save in local directory.</td></tr>
<tr><td>3</td><td>Save both the IL and ISA files in local directory.</td></tr>
</table>

Therefore, if you run your OpenCL program with:

```
    $ GPU_DUMP_DEVICE_KERNEL=3 ./my-program
```

You will get two files in your local directory:
`[kernel-name]_[device-name].il` and `[kernel-name]_[device-name].isa`, which
contain AMDIL and Device ISA disassembly, respectively.
