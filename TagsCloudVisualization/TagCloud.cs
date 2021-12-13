﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TagsCloudVisualization
{
    public class TagCloud
    {
        private readonly FileReader fileReader;
        private readonly TagCloudMaker tagCloudMaker;
        private readonly TagCloudVisualiser tagCloudVisualiser;

        public TagCloud(FileReader fileReader, TagCloudMaker tagCloudMaker, TagCloudVisualiser tagCloudVisualiser)
        {
            this.fileReader = fileReader;
            this.tagCloudMaker = tagCloudMaker;
            this.tagCloudVisualiser = tagCloudVisualiser;
        }

        public void CreateTagCloudFromFile(FileInfo source, Font font, int maxTegCount,
           Size resolution, string resultPath, ImageFormat format)
        {
            var text = fileReader.ReadFile(source);
            var tags = tagCloudMaker.CreateTagCloud(text, font, maxTegCount);
            var image = tagCloudVisualiser.Render(tags, resolution);
            image.Save(resultPath, format);
        }
    }
}