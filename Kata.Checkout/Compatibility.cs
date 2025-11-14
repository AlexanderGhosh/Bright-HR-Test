using System.ComponentModel;
// This file is used for compatibility with .net standard 2.0


#if NETSTANDARD2_0
namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit{}
}
#endif