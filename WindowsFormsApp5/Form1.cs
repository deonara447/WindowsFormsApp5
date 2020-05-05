using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{

    public partial class Form1 : Form
    {
        Random randGen = new Random();


        int bubbleLoopCounter;
        int selectionLoopCounter;
        int insertionLoopCounter;

        
        int bubbleComparisonCounter;
        int selectionComparisonCounter;
        int insertionComparisonCounter;
        
        int bubbleShiftCounter;
        int selectionShiftCounter;
        int insertionShiftCounter;
        public Form1()
        {
            InitializeComponent();
        }

        public void selection(int[] tempArray)
        {
            int temp;

            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    selectionLoopCounter++;
                    selectionComparisonCounter++;
                    if (tempArray[j] < tempArray[i])
                    {
                        temp = tempArray[i];
                        tempArray[i] = tempArray[j];
                        selectionShiftCounter++;
                        tempArray[j] = temp;
                        selectionShiftCounter++;
                    }
                }
            }
        }


        public void bubble(int[] tempArray)
        {
            int bottom = tempArray.Length - 1;
            int temp;
            Boolean sw = true;

            while (sw == true)
            {
                bubbleLoopCounter++;
                sw = false;

                for (int j = 0; j < bottom; j++)
                {
                    bubbleLoopCounter++;
                    bubbleComparisonCounter++;
                    if (tempArray[j] > tempArray[j + 1])
                    {
                        sw = true;
                        temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        bubbleShiftCounter++;
                        tempArray[j + 1] = temp;
                        bubbleShiftCounter++;
                    }
                }
                bottom--;
            }
        }



        public void insertion(int[] tempArray)
        {
            int temp, j;

            for (int n = 0; n < tempArray.Length; n++)
            {
                insertionLoopCounter++;

                temp = tempArray[n];
                j = n - 1;

                while (j >= 0 && tempArray[j] > temp)
                {
                    insertionLoopCounter++;

                    tempArray[j + 1] = tempArray[j];
                    insertionShiftCounter++;

                    j--;
                }

                tempArray[j + 1] = temp;
                insertionShiftCounter++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randomNumbers = Convert.ToInt32(textBox1.Text);

            int[] originalArray = new int[randomNumbers];
            int[] sortedArraySelection = new int[randomNumbers];
            int[] sortedArrayBubble = new int[randomNumbers];
            int[] sortedArrayInsertion = new int[randomNumbers];

            bubbleLoopCounter = selectionLoopCounter = insertionLoopCounter = bubbleComparisonCounter = selectionComparisonCounter = 
                insertionComparisonCounter = bubbleShiftCounter = selectionShiftCounter = insertionShiftCounter = 0;
            
            int i = 0;
            while (i < randomNumbers)
            {
                originalArray[i] = randGen.Next(-1000, 1001);
                i++;
            }
            originalArray.CopyTo(sortedArraySelection, 0);
            originalArray.CopyTo(sortedArrayBubble, 0);
            originalArray.CopyTo(sortedArrayInsertion, 0);
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            selection(sortedArraySelection);
            watch.Stop();
            long selectionTime = watch.ElapsedMilliseconds;
            watch.Reset();
            watch.Start();
            bubble(sortedArrayBubble);
            watch.Stop();
            long bubbleTime = watch.ElapsedMilliseconds;
            watch.Reset();
            watch.Start();
            insertion(sortedArrayInsertion);
            watch.Stop();
            long insertionTime = watch.ElapsedMilliseconds;

            textBox2.Text = "unsorted" + Environment.NewLine;
            textBox3.Text = "sorted" + Environment.NewLine;

            foreach (int z in originalArray)
            {
                textBox2.Text += z + Environment.NewLine;
            }

            foreach (int z in sortedArraySelection)
            {
                textBox3.Text += z + Environment.NewLine;
            }

            label18.Text = Convert.ToString(selectionTime);
            label19.Text = Convert.ToString(bubbleTime);
            label20.Text = Convert.ToString(insertionTime);

            label14.Text = Convert.ToString(selectionComparisonCounter);
            label15.Text = Convert.ToString(bubbleComparisonCounter);
            label16.Text = Convert.ToString(insertionComparisonCounter);

            label11.Text = Convert.ToString(selectionShiftCounter);
            label12.Text = Convert.ToString(bubbleShiftCounter);
            label13.Text = Convert.ToString(insertionShiftCounter);

            label8.Text = Convert.ToString(selectionLoopCounter);
            label9.Text = Convert.ToString(bubbleLoopCounter);
            label10.Text = Convert.ToString(insertionLoopCounter);
        }
    }
}
