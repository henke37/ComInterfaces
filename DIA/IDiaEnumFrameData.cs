using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DIA {
	[ComImport, Guid("9fc77a4b-3c1c-44ed-a798-6c1deea53e1f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDiaEnumFrameData {

		/// <summary>
		/// Gets the enumerator. Internally, marshals the COM IEnumVARIANT interface to the .NET Framework <see cref="IEnumerator"/> interface, and vice versa.
		/// </summary>
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler")]
		IEnumerator GetEnumerator();

		/// <summary>
		/// Retrieves the number of frame datas.
		/// </summary>
		[DispId(1)]
		int count { get; }

		/// <summary>
		/// Retrieves a frame data by means of an index.
		/// </summary>
		/// <param name="index">Index of the <see cref="IDiaFrameData"/> object to be retrieved. The index is the range 0 to count-1, where count is returned by the <see cref="IDiaEnumFrameData.count"/> property.</param>
		/// <returns>Returns an <see cref="IDiaFrameData"/> object representing the frame data.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		IDiaFrameData Item(
			[In] uint index);

		/// <summary>
		/// Retrieves a specified number of frame datas in the enumeration sequence.
		/// </summary>
		/// <param name="celt">The number of frame datas in the enumerator to be retrieved.</param>
		/// <param name="rgelt">Returns an array of <see cref="IDiaFrameData"/> objects that represents the desired frame datas.</param>
		/// <param name="pceltFetched">Returns the number of frame datas in the fetched enumerator.</param>
		void Next(
			[In] uint celt,
			[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDiaFrameData[] rgelt,
			[Out] out uint pceltFetched);

		/// <summary>
		/// Skips a specified number of frame datas in an enumeration sequence.
		/// </summary>
		/// <param name="celt">The number of frame datas in the enumeration sequence to skip.</param>
		void Skip(
			[In] uint celt);

		/// <summary>
		/// Resets an enumeration sequence to the beginning.
		/// </summary>
		void Reset();

		/// <summary>
		/// Creates an enumerator that contains the same enumeration state as the current enumerator.
		/// </summary>
		/// <returns>Returns an <see cref="IDiaEnumFrameData"/> object that contains a duplicate of the enumerator. The frame datas are not duplicated, only the enumerator.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		IDiaEnumFrameData Clone();


		[return: MarshalAs(UnmanagedType.Interface)]
		IDiaFrameData frameByRVA(ulong rva);

		[return: MarshalAs(UnmanagedType.Interface)]
		IDiaFrameData frameByVA(ulong va);
	}
}
