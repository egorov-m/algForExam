using System.Globalization;

namespace algForExam
{
    public static class ExternalSortExtensions
    {
        public class DirectMergeSorter
        {
            public string InputFilePath { get; set; }

            public string OutputFilePath { get; set; } = "sorted.csv";

            public int SortKey { get; set; }

            private long _seriesLength;

            private long _countSegments;

            private const string AuxiliaryFilePathA = "A.csv";

            private const string AuxiliaryFilePathB = "B.csv";

            private readonly Func<double, double, bool> _ascending = (x, y) => x < y; // Сортировка по возрастанию

            private readonly Func<double, double, bool> _descending = (x, y) => x < y; // Сортировка по убыванию

            public DirectMergeSorter(string filePath = "unsorted.csv", int sortKey = 0)
            {
                InputFilePath = filePath;
                SortKey = sortKey;
                _seriesLength = 1;
            }

            public void Sort() => Sort(_ascending);

            public void SortDescending() => Sort(_descending);

            private void Sort(Func<double, double, bool> order)
            {
                var index = 1;
                while (true)
                {
                    SplitToFiles();

                    if (_countSegments == 1) break;

                    Merge(order);
                }
            }

            private static int GetCountLinesFile(string filePath)
            {
                using var sr = new StreamReader(filePath);
                var count = 0;
                while ((sr.ReadLine()) != null)
                {
                    count++;
                }

                return count;
            }

            private void SplitToFiles()
            {
                _countSegments = 1;

                using var sr = _seriesLength == 1 ? new StreamReader(InputFilePath) : new StreamReader(OutputFilePath);

                using var swA = new StreamWriter(AuxiliaryFilePathA);
                using var swB = new StreamWriter(AuxiliaryFilePathB);

                var counter = 0L;
                var isFirstFile = true;

                var length = GetCountLinesFile(_seriesLength == 1 ? InputFilePath : OutputFilePath);
                var position = 0L;

                while (position != length)
                {
                    if (counter == _seriesLength)
                    {
                        isFirstFile = !isFirstFile;
                        counter = 0;
                        _countSegments++;
                    }

                    var str = sr.ReadLine();

                    position++;

                    if (isFirstFile)
                    {
                        swA.WriteLine(str);
                    }
                    else
                    {
                        swB.WriteLine(str);
                    }

                    counter++;
                }
            }

            private void Merge(Func<double, double, bool> comparer)
            {
                using var srA = new StreamReader(AuxiliaryFilePathA);
                using var srB = new StreamReader(AuxiliaryFilePathB);

                using var sw = new StreamWriter(OutputFilePath);

                var counterA = _seriesLength; 
                var counterB = _seriesLength;

                var strA = "";
                var strB = "";

                var isPickedA = false;
                var isPickedB = false;
                var isEndA = false;
                var isEndB = false;

                var lengthA = GetCountLinesFile(AuxiliaryFilePathA);
                var lengthB = GetCountLinesFile(AuxiliaryFilePathB);

                var positionA = 0L;
                var positionB = 0L;

                while (!isEndA || !isEndB)
                {
                    if (counterA == 0 && counterB == 0)
                    {
                        counterA = _seriesLength;
                        counterB = _seriesLength;
                    }

                    if (positionA != lengthA)
                    {
                        if (counterA > 0 && !isPickedA)
                        {
                            strA = srA.ReadLine();
                            positionA++;
                            isPickedA = true;
                        }
                    }
                    else
                    {
                        isEndA = true;
                    }

                    if (positionB != lengthB)
                    {
                        if (counterB > 0 && !isPickedB)
                        {
                            strB = srB.ReadLine();
                            positionB++;
                            isPickedB = true;
                        }
                    }
                    else
                    {
                        isEndB = true;
                    }

                    if (isPickedA)
                    {
                        if (isPickedB)
                        {
                            if (comparer(double.Parse(strA.Split(";")[SortKey], CultureInfo.InvariantCulture), double.Parse(strB.Split(";")[SortKey], CultureInfo.InvariantCulture)))
                            {
                                sw.WriteLine(strA);
                                counterA--;
                                isPickedA = false;
                            }
                            else
                            {
                                sw.WriteLine(strB);
                                counterB--;
                                isPickedB = false;
                            }
                        }
                        else
                        {
                            sw.WriteLine(strA);
                            counterA--;
                            isPickedA = false;
                        }
                    }
                    else if (isPickedB)
                    {
                        sw.WriteLine(strB);
                        counterB--;
                        isPickedB = false;
                    }
                }

                _seriesLength *= 2;
            }
        }

        public class NaturalMergeSorter
        {
            public string InputFilePath { get; set; }

            public string OutputFilePath { get; set; } = "sorted.csv";

            public int SortKey { get; set; }

            private bool _isPassageFirst = true;

            private long _countSegments;

            private const string AuxiliaryFilePathA = "A.csv";

            private const string AuxiliaryFilePathB = "B.csv";

            private readonly Func<double, double, bool> _ascending = (x, y) => x < y; // Сортировка по возрастанию

            private readonly Func<double, double, bool> _descending = (x, y) => x < y; // Сортировка по убыванию

            public NaturalMergeSorter(string filePath = "unsorted.csv", int sortKey = 0)
            {
                InputFilePath = filePath;
                SortKey = sortKey;
            }

            public void Sort() => Sort(_ascending);

            public void SortDescending() => Sort(_descending);

            private void Sort(Func<double, double, bool> order)
            {
                var index = 1;
                while (true)
                {
                    SplitToFiles(order);

                    if (_countSegments == 1) break;

                    Merge(order);
                }
            }

            private static int GetCountLinesFile(string filePath)
            {
                using var sr = new StreamReader(filePath);
                var count = 0;
                while (sr.ReadLine() != null)
                {
                    count++;
                }

                return count;
            }

            private void SplitToFiles(Func<double, double, bool> comparer)
            {
                _countSegments = 1;

                using var sr = _isPassageFirst ? new StreamReader(InputFilePath) : new StreamReader(OutputFilePath);

                using var swA = new StreamWriter(AuxiliaryFilePathA);
                using var swB = new StreamWriter(AuxiliaryFilePathB);

                var isStart = false;
                var isFirstFile = true;

                var length = GetCountLinesFile(_isPassageFirst ? InputFilePath : OutputFilePath);
                _isPassageFirst = false;
                var position = 0L;

                var str = "";
                var nextStr = "";

                if (length == 1)
                {
                    swA.WriteLine(sr.ReadLine());
                    return;
                }

                while (position != length)
                {
                    if (!isStart)
                    {
                        str = sr.ReadLine();
                        position++;

                        swA.WriteLine(str);
                        isStart = true;
                    }

                    nextStr = sr.ReadLine();

                    position++;

                    if (comparer(double.Parse(nextStr.Split(";")[SortKey], CultureInfo.InvariantCulture), double.Parse(str.Split(";")[SortKey], CultureInfo.InvariantCulture)))
                    {
                        isFirstFile = !isFirstFile;
                        _countSegments++;
                    }

                    if (isFirstFile)
                    {
                        swA.WriteLine(nextStr);
                    }
                    else
                    {
                        swB.WriteLine(nextStr);
                    }

                    str = nextStr;
                }
            }

            private void Merge(Func<double, double, bool> comparer)
            {
                using var srA = new StreamReader(AuxiliaryFilePathA);
                using var srB = new StreamReader(AuxiliaryFilePathB);

                using var sw = new StreamWriter(OutputFilePath);

                var strA = "";
                var strB = "";

                var isPickedA = false;
                var isPickedB = false;
                var isEndA = false;
                var isEndB = false;

                var lengthA = GetCountLinesFile(AuxiliaryFilePathA);
                var lengthB = GetCountLinesFile(AuxiliaryFilePathB);

                var positionA = 0L;
                var positionB = 0L;

                while (!isEndA || !isEndB || isPickedA || isPickedB)
                {
                    isEndA = positionA == lengthA;
                    isEndB = positionB == lengthB;

                    if (!isEndA && !isPickedA)
                    {
                        strA = srA.ReadLine();

                        positionA++;
                        isPickedA = true;
                    }

                    if (!isEndB && !isPickedB)
                    {
                        strB = srB.ReadLine();

                        positionB++;
                        isPickedB = true;
                    }

                    if (isPickedA)
                    {
                        if (isPickedB)
                        {
                            if (comparer(double.Parse(strA.Split(";")[SortKey], CultureInfo.InvariantCulture),
                                    double.Parse(strB.Split(";")[SortKey], CultureInfo.InvariantCulture)))
                            {
                                sw.WriteLine(strA);
                                isPickedA = false;
                            }
                            else
                            {
                                sw.WriteLine(strB);
                                isPickedB = false;
                            }
                        }
                        else
                        {
                            sw.WriteLine(strA);
                            isPickedA = false;
                        }
                    } else if (isPickedB)
                    {
                        sw.WriteLine(strB);
                        isPickedB = false;
                    }
                }
            }
        }

        public class MultiWayMergeSorter
        {
            private class HeadIndexPair
            {
                public string? Head { get; }
                public int Index { get; }

                public HeadIndexPair(string? head, int index)
                {
                    Head = head;
                    Index = index;
                }
            }

            public string InputFilePath { get; set; }

            public  string OutputFilePath { get; set; } = "sorted.csv";

            public int SortKey { get; set; }

            public int CountChunkRows { get; set; }

            public string ColumnSeparator { get; set; }

            private const string TmpFilePrefix = "tmpFile";
            private int _numChunk;

            public MultiWayMergeSorter(string inputFilePath = "unsorted.csv", int countChunkRows = 10, int sortKey = 0, string columnSeparator = ";")
            {
                InputFilePath = inputFilePath;
                CountChunkRows = countChunkRows;
                SortKey = sortKey;
                ColumnSeparator = columnSeparator;
            }

            public void Sort()
            {
                using var sr = new StreamReader(InputFilePath);
                var cnt = 0;

                var chunk = new string[CountChunkRows];

                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    chunk[cnt] = line;
                    cnt++;
                    if (cnt % CountChunkRows == 0)
                    {
                        SortAndSaveChunk(chunk, TmpFilePrefix + _numChunk);
                        cnt = 0;
                        _numChunk++;
                    }
                }

                if (cnt != 0)
                {
                    SortAndSaveChunk(chunk, TmpFilePrefix + _numChunk);
                    _numChunk++;
                }

                var readers = new StreamReader[_numChunk];

                var heads = new PriorityQueue<HeadIndexPair, HeadIndexPair>(Comparer<HeadIndexPair>.Create((a, b) => Compare(a.Head, b.Head)));

                for (var i = 0; i < _numChunk; i++)
                {
                    var strRead = new StreamReader(TmpFilePrefix + i);
                    readers[i] = strRead;
                }

                using (var streamOut = new StreamWriter(OutputFilePath))
                {
                    for (var i = 0; i < _numChunk; i++)
                    {
                        heads.Enqueue(new HeadIndexPair(readers[i].ReadLine(), i), new HeadIndexPair(readers[i].ReadLine(), i));
                    }

                    while (true)
                    {
                        var minH = heads.Count > 0 ? heads.Dequeue() : null;
                        if (null == minH) break;

                        streamOut.WriteLine(minH.Head);

                        if ((line = readers[minH.Index].ReadLine()) != null)
                            heads.Enqueue(new HeadIndexPair(line, minH.Index), new HeadIndexPair(line, minH.Index));
                    }

                    for (var i = 0; i < _numChunk; i++)
                    {
                        readers[i].Close();
                    }
                            
                }

                sr.Close();
            }

            private void SortAndSaveChunk(string?[] chunk, string filename)
            {
                Array.Sort(chunk, Compare);
                using var sw = new StreamWriter(filename);
                foreach (var t in chunk)
                {
                    if (t != null) sw.WriteLine(t);
                }

                sw.Close();
            }

            private string ExtractCol(string line)
            {
                var columns = line.Split(ColumnSeparator);
                return columns[SortKey];
            }

            private int Compare(string? a, string? b)
            {
                if (a == null && b == null) return 0;
                if (a == null) return 1;
                if (b == null) return -1;
                return string.Compare(ExtractCol(a), ExtractCol(b), StringComparison.Ordinal);
            }
        }
    }
}
