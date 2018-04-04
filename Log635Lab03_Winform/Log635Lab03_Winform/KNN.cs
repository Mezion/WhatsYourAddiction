using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////////////////////
using System.IO;

namespace Log635Lab03_Winform
{
    //extension method to aid in algorithm implementation
    public static class Extensions
    {
        //converts string representation of number to a double
        public static IEnumerable<double> ConvertToDouble<T>(this IEnumerable<T> array)
        {
            dynamic ds;
            foreach (object st in array)
            {
                ds = st;
                yield return Convert.ToDouble(ds);
            }
        }

        //returns a row in a 2D array
        public static T[] Row<T>(this T[,] array, int r)
        {
            T[] output = new T[array.GetLength(1)];
            if (r < array.GetLength(0))
            {
                for (int i = 0; i < array.GetLength(1); i++)
                    output[i] = array[r, i];
            }
            return output;
        }

        //converts a List of Lists to a 2D matrix
        public static T[,] ToMatrix<T>(this IEnumerable<List<T>> collection, int depth, int length)
        {
            T[,] output = new T[depth, length];
            int i = 0, j = 0;
            foreach (var list in collection)
            {
                foreach (var val in list)
                {
                    output[i, j] = val;
                    j++;
                }
                i++; j = 0;
            }

            return output;
        }

        //returns the classification that appears most frequently in the array of classifications
        public static string Majority<T>(this T[] array)
        {
            if (array.Length > 0)
            {
                int unique = array.Distinct().Count();
                if (unique == 1)
                    return array[0].ToString();

                return (from item in array
                        group item by item into g
                        orderby g.Count() descending
                        select g.Key).First().ToString();
            }
            else
                return "";
        }
    }

    public class KNN
    {
        private DrugDataset _dataset;

        //////////////////////////////////////////////////////////////////////
        //private members
        private Dictionary<List<double>, string> dataSet = new Dictionary<List<double>, string>();
        private List<double> originalStatsMin = new List<double>();
        private List<double> originalStatsMax = new List<double>();
        private int k = 0;
        private int length = 0;
        private int depth = 0;
        //////////////////////////////////////////////////////////////////////

        public KNN(DrugDataset dataset)
        {
            //_dataset = dataset;
            //_dataset.Columns.ForEach(c => {
            //    var rows =_dataset.GetRows(c);


            //});
            //var list = _dataset.GetRows("Nicotine");
            //_dataset.CleanAllColumns();

            //var listDoubles = list.Select(d => double.Parse(d)).ToList();

            

            //Start -----------------------------------------------------------
            KNN examplekNN = KNN.initialiseKNN(3, "DataSet.txt");

            //List<double> instance2Classify = new List<double> { 12, 11, 500 };

            //foreach (DataRow row in DrugDataTable.Rows)
            //{
            //    tempList.Add(row[columnName].ToString());
            //}

            List<double> instance2Classify = new List<double> { 12, 11, 500 };
            string result = examplekNN.Classify(instance2Classify);
            //-----------------------------------------------------------------
        }

        private  KNN(int K, string FileName)
        {
            k = K;
            PopulateDataSetFromFile(FileName);
        }

        public void Train()
        {

        }

        /// <summary>
        /// Initialises the kNN class, the observations data set and the number of neighbors to use in voting when classifying
        /// </summary>
        /// <param name="K">integer representiong the number of neighbors to use in the classifying instances</param>
        /// <param name="FileName">string file name containing knows numeric observations with string classes</param>
        public static KNN initialiseKNN(int K, string FileName)
        {
            if (K % 2 > 0)
                return new KNN(K, FileName);
            else
            {
                Console.WriteLine("K must be odd.");
                return null;
            }
        }

        /// Classifies the instance according to a kNN algorithm
        /// calculates Eucledian distance between the instance and the know data
        /// <param name="instance">List of doubles representing the instance values</param>
        /// <returns>returns string - classification</returns>
        internal string Classify(List<double> instance)
        {
            int i = 0;
            double[] normalisedInstance = new double[length];

            if (instance.Count != length)
            {
                return "Wrong number of instance parameters.";
            }

            foreach (var one in instance)
            {
                normalisedInstance[i] = (one - originalStatsMin.ElementAt(i)) / (originalStatsMax.ElementAt(i) - originalStatsMin.ElementAt(i));
                i++;
            }

            double[,] keyValue = dataSet.Keys.ToMatrix(depth, length);
            double[] distances = new double[depth];

            Dictionary<double, string> distDictionary = new Dictionary<double, string>();
            for (i = 0; i < depth; i++)
            {
                distances[i] = Math.Sqrt(keyValue.Row(i).Zip(normalisedInstance, (one, two) => (one - two) * (one - two)).ToArray().Sum());
                distDictionary.Add(distances[i], dataSet.Values.ToArray()[i]);

            }

            //select top votes
            var topK = (from d in distDictionary.Keys
                        orderby d ascending
                        select d).Take(k).ToArray();

            //obtain the corresponding classifications for the top votes
            var result = (from d in distDictionary
                          from t in topK
                          where d.Key == t
                          select d.Value).ToArray();

            return result.Majority();
        }

        /// Processess the file with the comma separated training data and populates the dictionary
        /// all values except for the class must be numeric
        /// the class is the last element in the dataset for each record
        /// <param name="fileName">string fileName - the name of the file with the training data</param>
        private void PopulateDataSetFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, true))
            {
                List<string> allItems = sr.ReadToEnd().TrimEnd().Split('\n').ToList();

                if (allItems.Count > 1)
                {
                    string[] array = allItems.ElementAt(0).Split(',');
                    length = array.Length - 1;
                    foreach (string item in allItems)
                    {
                        array = item.Split(',');
                        dataSet.Add(array.Where(p => p != array.Last()).ConvertToDouble().ToList(), array.Last().ToString().TrimEnd());
                    }
                    array = null;
                }
                else
                    Console.WriteLine("No items in the data set");
            }
        }
    }
}
