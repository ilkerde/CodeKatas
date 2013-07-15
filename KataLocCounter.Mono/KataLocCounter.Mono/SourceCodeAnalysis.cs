using System;
using System.Linq;
using NUnit.Framework;

namespace KataLocCounter.Mono
{
	public class SourceCodeAnalysis
	{
		private class BlockCommentState
		{
			public bool IsActive { get; set; } 
		}

		public static int CountLinesOfCode(string sourceCode)
		{
			var blockCommentState = new BlockCommentState();
			var sourceCodeLines = sourceCode.SplitLinesToArray();
			return sourceCodeLines.Count(x => IsCodeLine(x, blockCommentState));
		}

		private static bool IsCodeLine(string sourceCodeLine, BlockCommentState blockCommentState) {
			sourceCodeLine = sourceCodeLine.Trim();

			if (sourceCodeLine.StartsWith ("/*")) 
			{
				blockCommentState.IsActive = true;

				if (HasBlockCommentTerminator(sourceCodeLine))
					return IsBlockCommentTerminatedBeforeEOL(sourceCodeLine);

				return false;
			}

			if (sourceCodeLine.EndsWith ("*/")) {
				blockCommentState.IsActive = false;
				return false;
			}

			if (blockCommentState.IsActive)
				return false;

			return !String.IsNullOrEmpty(sourceCodeLine) 
				&& !sourceCodeLine.StartsWith("//");
		}

		private static bool IsBlockCommentTerminatedBeforeEOL(string sourceCodeLine)
		{
			return sourceCodeLine.IndexOf ("*/") < sourceCodeLine.Length - 2;
		}

		private static bool HasBlockCommentTerminator(string sourceCodeLine)
		{
			return sourceCodeLine.Contains("*/");
		}

	}
}