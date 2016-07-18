using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Oriented Data created classes extending the Microsoft .Net System.IO namespace.
/// </summary>
namespace OD.IO
{
	/// <summary>
	/// Enumerate through a file system tree structure.
	/// </summary>
	public class FileEnumerator : IEnumerator<string>
	{
		private string[] files;
		private string[] directories;
		private int filePointer;
		private int directoryPointer;
		private string current;

		private FileEnumerator dirScanner;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileEnumerator"/> class.
		/// </summary>
		/// <param name="directory">The directory.</param>
		public FileEnumerator(string directory)
		{
			CurrentDirectory = directory;
			Reset();
		}
		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		public string Current
		{
			get
			{
				return current;
			}
		}

		/// <summary>
		/// Gets the current directory.
		/// </summary>
		/// <value>
		/// The current directory.
		/// </value>
		public string CurrentDirectory { get; private set; }

		object IEnumerator.Current
		{
			get
			{
				return current;
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			dirScanner = null;
			GC.Collect();
		}

		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns>
		/// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
		/// </returns>
		public bool MoveNext()
		{
			if (filePointer < files.Length)
			{
				current = files[filePointer];
				filePointer++;
				return true;
			}
			else
				return CheckDirectory();
		}

		/// <summary>
		/// Checks the directory.
		/// </summary>
		/// <returns></returns>
		public bool CheckDirectory()
		{
			if (directoryPointer < directories.Length)
			{
				if (dirScanner == null)
					dirScanner = new FileEnumerator(directories[directoryPointer]);

				if (dirScanner.MoveNext())
				{
					current = dirScanner.Current;
					return true;
				}
				else
				{
					directoryPointer++;
					dirScanner = null;
					return CheckDirectory();
				}
			}
			else
				return false;
		}

		/// <summary>
		/// Sets the enumerator to its initial position, which is before the first element in the collection.
		/// </summary>
		public void Reset()
		{
			if (CurrentDirectory.Trim() != string.Empty && Directory.Exists(CurrentDirectory))
			{
				files = Directory.GetFiles(CurrentDirectory);
				directories = Directory.GetDirectories(CurrentDirectory);
			}
			else
			{
				files = new string[] { };
				directories = new string[] { };
			}

			dirScanner = null;
			filePointer = 0;
			directoryPointer = 0;
			current = string.Empty;
		}
	}
}
