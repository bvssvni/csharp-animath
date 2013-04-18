using System;
using System.Collections.Generic;
using Cairo;
using Utils;

namespace Animath
{
	public class Document
	{
		public Dictionary<int, Image> Images;
		public Dictionary<int, SpriteSequence> SpriteSequences;
		public Dictionary<int, Frame> Frames;

		public struct Rect {
			public int X;
			public int Y;
			public int Width;
			public int Height;
		}

		public struct Image {
			public string Filename;
			public ImageSurface ImageSurface;
		}

		public struct SpriteSequence {
			// Images is a shared resource, so we use ids.
			public Cheap<int> ImageIds;
			public Cheap<Rect> Rects;
		}

		public struct Layer {
			public int SelectedSpriteId;
			public int SpriteSequenceId;
			public Cheap<Layer> SubLayers;
		}

		public struct Frame {
			public Cheap<Layer> Layers;
		}

		public void Defragment() {
			Cheap<int>.Defragment();
			Cheap<Layer>.Defragment();
			Cheap<Rect>.Defragment();
		}
	}
}

