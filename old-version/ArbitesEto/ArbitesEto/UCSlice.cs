﻿using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    public partial class UCSlice
    {
        public List<UCLayer> layers { get; set; }
        public ClLayoutContainer layout { get; set; }
        public ClBoardSlice sliceInfo { get; set; }
        public int sliceIndex { get; set; }
        public UCSlice()
        {
            InitializeComponent();
            layers = new List<UCLayer>();
            sliceIndex = 0;
        }

        public UCSlice(ClBoardSlice input, ClLayoutContainer layout)
        {
            InitializeComponent();
            this.layout = layout;
            layers = new List<UCLayer>();
            LName.Text = input.sliceName;
            this.sliceInfo = input;
            this.sliceIndex = input.sliceIndex;

            for (int i = 0; i < layout.keys.Count; i++)
            {
                AddLayer(i, true);

            }
        }


        public void AddLayer(int layer, bool init)
        {
            var nl = new UCLayer(sliceInfo.keys, sliceInfo.sliceIndex, layer, this.layout, init);
            SLMain.Items.Add(nl);
            layers.Add(nl);
            //MessageBox.Show("Added to client");
            //ClientSize = new Size(layers[0].ClientSize.Width + 30, layers[0].ClientSize.Height * layers.Count + 30);
            //ClientSize = new Size(472, 1023);
            //MessageBox.Show(layers[0].ClientSize.Width.ToString());
        }

        public void LoadLayout(ClLayoutContainer input)
        {
            this.layout = input;

            while (layout.keys.Count < layers.Count)
            {
                this.SLMain.Items.RemoveAt(layers.Count - 1);
                layers.RemoveAt(layers.Count - 1);
            }
            int tempi = layers.Count;
            while (layers.Count < layout.keys.Count)
            {
                if (layout.keys[tempi].Count == sliceInfo.keys.Count)
                {

                    AddLayer(layers.Count, false);
                }
                else
                {

                    AddLayer(layers.Count, true);
                }
                tempi++;

            }
            foreach (UCLayer layer in layers)
            {
                layer.LoadLayout(layout);
            }


        }
    }
}
