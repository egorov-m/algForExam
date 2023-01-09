# Алгоритмы: Материалы для экзамена.

## Оглавление

- [Оглавление](#оглавление)
- [Билет 1: Пузырьковая сортировка (Bubble Sort)](#билет-1-пузырьковая-сортировка-bubble-sort)
  - [Описание](#билет-1-пузырьковая-сортировка-bubble-sort)
  - [Реализация (C# пример)](./algForExam/BubbleSortExtensions.cs)
- [Билет 2: Сортировка вставками (Insertion Sort)](#билет-2-сортировка-вставками-insertion-sort)
  - [Описание](#билет-2-сортировка-вставками-insertion-sort)
  - [Реализация (C# пример)](./algForExam/InsertionSortExtensions.cs)
- [Билет 3: Сортировка выбором (Selection Sort)](#билет-3-сортировка-выбором-selection-sort)
  - [Описание](#билет-3-сортировка-выбором-selection-sort)
  - [Реализация (C# пример)](./algForExam/SelectionSortExtensions.cs)
- [Билет 4: “Шейкерная” сортировка (Сортировка перемешиванием, Двунаправленная сортировка, Cocktail Sort)](#билет-4-шейкерная-сортировка-сортировка-перемешиванием-двунаправленная-сортировка-cocktail-sort)
  - [Описание](#билет-4-шейкерная-сортировка-сортировка-перемешиванием-двунаправленная-сортировка-cocktail-sort)
  - [Реализация (C# пример)](./algForExam/CocktailSortExtensions.cs)
- [Билет 5: Сортировка Шелла (Shell Sort)](#билет-5-сортировка-шелла-shell-sort)
  - [Описание](#билет-5-сортировка-шелла-shell-sort)
  - [Реализация (C# пример)](./algForExam/CocktailSortExtensions.cs)
- [Билет 6: Алгоритм бинарного (двоичного) поиска (Binary Search)](#билет-6-алгоритм-бинарного-двоичного-поиска-binary-search)
  - [Описание](#билет-6-алгоритм-бинарного-двоичного-поиска-binary-search)
  - [Реализация (C# пример)](./algForExam/BinarySearchExtensions.cs)
- [Билет 7: Быстрая сортировка (Quick Sort)](#билет-8-внешняя-сортировка-слиянием-external-merge-sort)
  - [Описание](#билет-8-внешняя-сортировка-слиянием-external-merge-sort)
  - [Реализация (C# пример)](./algForExam/QuickSortExtensions.cs)
- [Билет 8: Внешняя сортировка слиянием (External merge sort)](#билет-8-внешняя-сортировка-слиянием-external-merge-sort)
  - [Описание](#билет-8-внешняя-сортировка-слиянием-external-merge-sort)
  - [Реализация (C# пример)](./algForExam/ExternalSortExtensions.cs)
- [Билет 9: Сортировка с помощью двоичного дерева (Tree Sort)](#билет-9-сортировка-с-помощью-двоичного-дерева-tree-sort)
  - [Описание](#билет-9-сортировка-с-помощью-двоичного-дерева-tree-sort)
  - [Реализация (C# пример)](./algForExam/TreeSortExtensions.cs)
- [Билет 10: Поразрядная сортировка (Radix Sort)](#билет-10-поразрядная-сортировка-radix-sort)
  - [Описание](#билет-10-поразрядная-сортировка-radix-sort)
  - [Реализация (C# пример)](./algForExam/RadixSortExtensions.cs)
- [Билет 11: Хэш-таблицы с разрешением коллизий методом цепочек](#билет-11-хэш-таблицы-с-разрешением-коллизий-методом-цепочек)
  - [Описание](#билет-11-хэш-таблицы-с-разрешением-коллизий-методом-цепочек)
  - [Реализация (C# пример)](./algForExam/Dictionary.cs)
- [Билет 12: Хэш-таблицы с разрешением коллизий методом открытой адресации](#билет-12-хэш-таблицы-с-разрешением-коллизий-методом-открытой-адресации)
  - [Описание](#билет-12-хэш-таблицы-с-разрешением-коллизий-методом-открытой-адресации)
  - [Реализация (C# пример)](./algForExam/Hashtable.cs)
- [Билет 13: ABC сортировка для строк (Allen Beechick Character Sort for string)](#билет-13-abc-сортировка-для-строк-allen-beechick-character-sort-for-string)
  - [Описание](#билет-13-abc-сортировка-для-строк-allen-beechick-character-sort-for-string)
  - [Реализация (C# пример)](./algForExam/ABCSortExtensions.cs)
- [Билет 14: Реализовать стек и базовые операции работы со стеком, с использованием собственного двусвязного списка](#билет-14-реализовать-стек-и-базовые-операции-работы-со-стеком-с-использованием-собственного-двусвязного-списка)
  - [Описание](#билет-14-реализовать-стек-и-базовые-операции-работы-со-стеком-с-использованием-собственного-двусвязного-списка)
  - [Реализация (C# пример)](./algForExam/Stack.cs)

## Билет 1: Пузырьковая сортировка (Bubble Sort)

### Описание
Простейший алгоритм сортировки, который многократно меняет местами соседние элементы, если они расположены в неправильном порядке. Проход по списку повторяется до тех пор, пока список не будет отсортирован.

**Сложность:** *O(n^2)*, в лучшем случае (коллекция уже отсортирована) *O(n)*, алгоритм не подходит для большинства наборов данных, поскольку его временная сложность в среднем и худшем случае довольно высока.

**Вспомогательное пространство:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/bubble-sort/

### [Реализация (C# пример)](./algForExam/BubbleSortExtensions.cs)
```cs
public static IList<T> BubbleSort<T>(this IList<T> collection) where T : IComparable
{
    for (var i = 0; i < collection.Count; i++)
    {
        for (var j = i + 1; j < collection.Count; j++)
        {
            if (collection[i].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
            {
                (collection[j], collection[i]) = (collection[i], collection[j]);
            }
        }
    }

    return collection;
}
```

## Билет 2: Сортировка вставками (Insertion Sort)

### Описание
Простой алгоритм сортировки, который работает аналогично тому, как происходит сортировка игральных карт в руках. Массив мысленно разделён на отсортированную и неотсортированную части. Значения из несортированной части выбираются и помещаются в правильную позицию в отсортированной части.

Этот алгоритм является одним из самых простых в реализации, эффективен для небольших наборов данных, носит адоптивный характер: подходит для частично отсортированных наборов.

**Сложность:**
- <u>Лучший случай:</u> *O(n)*, возникает в случае, если массив уже отсортирован;
- <u>Средний случай:</u> *O(n^2)*, элементы перемешаны в порядке так, что порядок не является должным образов возрастающим или убывающим;
- <u>Худший случай:</u> *O(n^2)*, возникает в случае, когда массив уже отсортирован в обратном порядке;

**Вспомогательное пространство:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/insertion-sort/

### [Реализация (C# пример)](./algForExam/InsertionSortExtensions.cs)
```cs
public static IList<T> InsertionSort<T>(this IList<T> collection) where T : IComparable
{
    for (var i = 1; i < collection.Count; i++)
    {
        var item = collection[i];
        var j = i - 1;

        while (j >= 0 && collection[j].CompareTo(item) > 0) // Сортировка по возрастанию
        {
            collection[j + 1] = collection[j];
            j--;
        }

        collection[j + 1] = item;
    }

    return collection;
}
```

## Билет 3: Сортировка выбором (Selection Sort)

### Описание
Алгоритм сортирует массив, многократно находя минимальный элемент (с учётом возрастания) из несортированной части и помещая его в начало. Алгоритм поддерживает два под массива в заданном массиве: под массив, который уже отсортирован, оставшийся под массив — неотсортированный.

По-умолчанию реализация алгоритма не [стабильна*](#стабильный-алгоритм). Однако этого можно достичь путём замены операции смены элементов местами на операцию толкания элементов вперёд.

#### Стабильный алгоритм:
Тот алгоритм, который не меняет порядок элементов с одинаковыми ключами относительно друг друга.

**Сложность:** *O(n^2)* — во всех случаях, так-как есть два вложенных цикла: один цикл для выбора элемента массива один за другим *O(n)*, другой цикл для сравнения этого элемента с любым другим *O(n)*.

**Вспомогательное пространство:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/selection-sort, https://www.geeksforgeeks.org/stable-selection-sort/

### [Реализация (C# пример)](./algForExam/SelectionSortExtensions.cs)
```cs
public static IList<T> SelectionSort<T>(this IList<T> collection) where T : IComparable
{
    for (var i = 0; i < collection.Count - 1; i++)
    {
        var index = i;
        for (var j = i + 1; j < collection.Count; j++)
        {
            if (collection[index].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
            {
                index = j;
            }
        }

        (collection[index], collection[i]) = (collection[i], collection[index]);
    }

    return collection;
}
```

## Билет 4: “Шейкерная” сортировка (Сортировка перемешиванием, Двунаправленная сортировка, Cocktail Sort)

### Описание
Разновидность [пузырьковой сортировки](#билет-1-пузырьковая-сортировка-bubble-sort). Алгоритм пузырьковой сортировки всегда обходит элементы слева и перемещает самый большой элемент в правильное положение на первой итерации, второй по величине — на второй и так далее. Коктейльная сортировка попеременно проходит через заданный массив в обоих направлениях. Коктейльная сортировка не требует ненужных итераций, что делает ее эффективной для больших массивов.

**Каждая итерация алгоритма разбивается на два этапа:**
1. Первый этап перебирает массив слева направо, как и при пузырьковой сортировке. Во время цикла сравниваются соседние элементы, и если значение слева больше значения справа, значения меняются местами. В конце первой итерации наибольшее число будет находиться в конце массива.
2. Второй этап проходит по массиву в обратном направлении — начиная с элемента, непосредственно предшествующего последнему отсортированному элементу, и возвращаясь к началу массива. Здесь также сравниваются соседние элементы и при необходимости меняются местами.

**Сравнение с пузырьковой сортировкой:** временная сложность такая же, но Коктельная сортировка работает лучше, чем пузырьковая, обычно мене чем в два раза быстрее.

**Сложность:** *O(n^2)*, в лучшем случае (коллекция уже отсортирована) *O(n)*.

**Вспомогательное пространство:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/cocktail-sort/

### [Реализация (C# пример)](./algForExam/CocktailSortExtensions.cs)
```cs
public static IList<T> CocktailSort<T>(this IList<T> collection) where T : IComparable
{
    for (var i = 0; i < collection.Count; i++)
    {
        var needSort = false;
        for (var j = i; j < collection.Count - 1 - i; j++)
        {
            if (collection[j].CompareTo(collection[j + 1]) > 0) // Сортировка по возрастанию
            {
                (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
                needSort = true;
            }
        }

        for (var j = collection.Count - 2 - i; j > i; j--)
        {
            if (collection[j - 1].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
            {
                (collection[j], collection[j - 1]) = (collection[j - 1], collection[j]);
                needSort = true;
            }
        }

        if (!needSort) return collection;
    }

    return collection;
}
```

## Билет 5: Сортировка Шелла (Shell Sort)

### Описание
Это обобщённая версия [алгоритма сортировки вставками](#билет-2-сортировка-вставками-insertion-sort). Сначала сортируются элементы, находящиеся далеко друг от друга, и последовательно уменьшается интервал между сортируемыми элементами, таким образом выполняется меньше обменов.

Интервал между сортируемыми элементами сокращается в зависимости от используемой последовательности. Вот несколько оптимальных последовательностей:
- Оригинальная последовательность Shell: *N/2*, *N/4*, *...*, *1*;
- Последовательность Кнута: *1*, *4*, *13*, ..., *(3^k - 1) / 2*;
- Последовательность Седжвика: *1*, *8*, *23*, *77*, *281*, *1073*, *4193*, *16577...4j+1+ 3\*2j+ 1*;
- Приращение Хиббарда: *1*, *3*, *7*, *15*, *31*, *63*, *127*, *255*m *511*, *...*;
- Последовательность Папернова и Стасевича: *1*, *3*, *5*, *9*, *17*, *33*, *65*, *...*;
- Последовательность Пратт: *1, 2, 3, 4, 6, 9, 8, 12, 18, 27, 16, 24, 36, 54, 81, ...*;

**Сложность:** 
- <u>Лучший случай:</u> *O(n\*log(n))*, возникает в случае, если массив уже отсортирован, общее количество сравнений для каждого интервала равно размеру массива;
- <u>Средний случай:</u> *O(n\*log(n))*, около *O(n^1.25)*;
- <u>Худший случай:</u> *O(n^2)*, согласно теореме Пунена — сложность равна что-то вроде: *O(n \* log(n))^2 / (log(log(n))^2)* или *O(n \* log(n))^2 / log(log(n))* или *O(n \* (log(n))^2)*

Сложность зависит от выбранной последовательности, для каждой конкретной отличается. Лучшая последовательность неизвестна.

**Вспомогательное пространство:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/shellsort, https://www.programiz.com/dsa/shell-sort

### [Реализация (C# пример)](./algForExam/CocktailSortExtensions.cs)
```cs
public static IList<T> ShellSort<T>(this IList<T> collection) where T : IComparable
{
    var step = collection.Count / 2;
    while (step > 0)
    {
        step /= 2;
        for (var i = step; i < collection.Count; i++)
        {
            var j = i;
            while (j >= step && collection[j - step].CompareTo(collection[j]) > 0) // Сортировка по возрастанию
            {
                (collection[j], collection[j - step]) = (collection[j - step], collection[j]);
                j -= step;
            }
        }
    }

    return collection;
}
```

## Билет 6: Алгоритм бинарного (двоичного) поиска (Binary Search)

### Описание
Алгоритм поиска, используемый в отсортированном массиве путём многократного деления интервала поиска пополам. Идея состоит в том, чтобы использовать информацию о том, что массив отсортирован, и уменьшить временную сложность до *O(log(n))*.

Может быть реализован двумя способами: итерационный метод, рекурсивный метод — подход "разделяй и властвуй".

**Сложность (рекурсивный, итеративный метод):** *O(log(n))*, в лучшем случае *O(n)*.

**Вспомогательное пространство (рекурсивный метод):** *O(log(n))*.

**Вспомогательное пространство (итеративный метод):** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/binary-search/, https://www.programiz.com/dsa/binary-search

### [Реализация (C# пример)](./algForExam/BinarySearchExtensions.cs)

#### Рекурсивный метод
```cs
private static int BinarySearchRecursive<T>(this IList<T> collection, T key, int left, int right) where T : IComparable
{
    if (right < left) throw new ArgumentOutOfRangeException("Левая / правая граница указана неправильно.");

    var mid = left + (right - left) / 2; // ! вычислять нужно именно так
    var value = collection[mid];

    if (key.Equals(value)) return mid;

    return value.CompareTo(key) > 0 // Коллекция отсортирована по возрастанию
        ? collection.BinarySearchRecursive(key, left, mid - 1)
        : collection.BinarySearchRecursive(key, mid + 1, right);
}
```

#### Итеративный метод
```cs
private static int BinarySearchIterative<T>(this IList<T> collection, T key, int left, int right) where T : IComparable
{
    while (left <= right)
    {
        var mid = left + (right - left) / 2; // ! вычислять нужно именно так
        var value = collection[mid];

        if (key.Equals(value)) return mid;

        if (value.CompareTo(key) > 0) // Коллекция отсортирована по возрастанию
        {
            right = mid - 1;
        }
        else
        {
            left = mid + 1;
        }
    }

    throw new ArgumentOutOfRangeException("Левая / правая граница указана неправильно.");
}
```

## Билет 7: Быстрая сортировка (Quick Sort)

### Описание
Алгоритм быстрой сортировки представляет собой алгоритм «разделяй и властвуй». Первоначально он выбирает элемент в качестве опорного элемента и разбивает данный массив вокруг выбранного опорного элемента. Существует много разных версий QuickSort, которые по-разному выбирают точку опоры: 1. всегда выбирайте первый элемент в качестве опорного, 2. всегда выбирайте последний элемент в качестве опорного, 3. выберите случайный элемент в качестве точки опоры, 4. выберите медиану в качестве точки опоры. Также есть несколько схем разделения.

#### Схема разделения Ломуто
Предполагается, что опорный элемент является последним. Теперь инициализируется два счётчика: *i* и *j*. Выполняется итерация по массиву, увеличивается *i*, если *array[i] <= pivot(array[i] >= pivot)*, и заменяется *array[i]* на *array[j]*, в противном случае увеличивается только счётчик *j*. После выхода из цикла, меняются местами *array[i]* и *array[pivotIndex]*.

#### Схема разделения Хоара
(в целом более эффективен - в среднем делает в три раза меньше свопов):
Работает по принципу инициализации двух указателей, которые указывают на массив с начала и конца. Они двигаются друг к другу до тех пор, пока не будет найдена ситуация, когда меньше(больше) значение справа, а больше(меньше) значение слева, относительно опорного элемента. После этого два значения меняются местами.

**Замечание:** Если в качестве опорного элемента выбирать последний, то схема разделения Хоара может привезти к тому, что QuickSort уйдёт в бесконечную рекурсию, в этом случае нужно будет произвести замену элемента.

**Сложность:**
- <u>Лучший случай:</u> *O(n * log(n))*, возникает в случае, когда опорный элемент является средним элементом или рядом со средним;
- <u>Худший случай:</u> *O(n2)*, возникает в случае, когда выбранный опорный элемент является самым большим или самым маленьким;
- <u>Средний случай:</u> *O(n * log(n))*, происходит в случае, когда вышеуказанные условия не возникают;

Дополнительно: https://www.geeksforgeeks.org/quick-sort/, https://www.geeksforgeeks.org/hoares-vs-lomuto-partition-scheme-quicksort/, https://www.programiz.com/dsa/quick-sort

### [Реализация (C# пример)](./algForExam/QuickSortExtensions.cs)

#### Метод разделения Ломуто
```cs
private static IList<T> QuickSortLomuto<T>(this IList<T> collection, int left, int right) where T : IComparable
{
    if (left >= right) return collection;
    var pivot = collection.PartitionLomuto(left, right);
    QuickSortLomuto(collection, left, pivot - 1);
    QuickSortLomuto(collection, pivot + 1, right);

    return collection;
}

private static int PartitionLomuto<T>(this IList<T> collection, int left, int right) where T : IComparable
{
    var pivot = left - 1; // В качестве опорного элемента выбирается самый левый элемент
    for (var i = left; i < right; i++)
    {
        if (collection[right].CompareTo(collection[i]) > 0) // Сортировка по возрастанию
        {
            pivot++;
            (collection[pivot], collection[i]) = (collection[i], collection[pivot]);
        }
    }

    pivot++;
    (collection[pivot], collection[right]) = (collection[right], collection[pivot]);

    return pivot;
}
```

#### Метод разделения Хоара
```cs
private static IList<T> QuickSortHoare<T>(this IList<T> collection, int left, int right) where T : IComparable
{
    if (left < right)
    {
        var pivot = collection.PartitionHoare(left, right);
        collection.QuickSortHoare(left, pivot);
        collection.QuickSortHoare(pivot + 1, right);
    }

    return collection;
}

private static int PartitionHoare<T>(this IList<T> collection, int left, int right) where T : IComparable
{
    var pivot = collection[left]; // В качестве опорного элемента выбирается самый левый элемент

    var i = left - 1;
    var j = right + 1;

    while (true)
    {
        do
        {
            i++;
        } while (pivot.CompareTo(collection[i]) > 0); // Сортировка по возрастанию

        do
        {
            j--;
        } while (collection[j].CompareTo(pivot) > 0); // Сортировка по возрастанию

        if (i >= j)
        {
            return j;
        }

        (collection[i], collection[j]) = (collection[j], collection[i]);
    }
}
```

## Билет 8: Внешняя сортировка слиянием (External merge sort)

### Описание
**Внешняя сортировка** – это сортировка данных, которые расположены на внешних устройствах и не вмещающихся в оперативную память.

Основным понятием при использовании внешней сортировки является понятие серии. **Серия (упорядоченный отрезок)** – это последовательность элементов, которая упорядочена по ключу. Максимальное количество серий в файле *N* (все элементы не упорядочены). Минимальное количество серий одна (все элементы упорядочены).

В основе большинства методов внешних сортировок лежит процедура слияния и процедура распределения. **Слияние** – это процесс объединения двух (или более) упорядоченных серий в одну упорядоченную последовательность при помощи циклического выбора элементов, доступных в данный момент. **Распределение** – это процесс разделения упорядоченных серий на два и несколько вспомогательных файла.

**Фаза** – это действия по однократной обработке всей последовательности элементов. **Двухфазная сортировка** – это сортировка, в которой отдельно реализуется две фазы: распределение и слияние. **Однофазная сортировка** – это сортировка, в которой объединены фазы распределения и слияния в одну.

**Двухпутевым слиянием** называется сортировка, в которой данные распределяются на два вспомогательных файла. **Многопутевым слиянием** называется сортировка, в которой данные распределяются на *N (N > 2)* вспомогательных файлов.

#### Сортировка простым слиянием (прямое слияние, Direct merge sort)
В данном алгоритме длина серий фиксируется на каждом шаге. В исходном файле все серии имеют длину *1*, после первого шага она равна *2*, после второго – *4*, после третьего – *8*, после *k-го* шага – *2^k*.

***Алгоритм:***
1. Исходный файл *f* разбивается на два вспомогательных файла *f1* и *f2*.
2. Вспомогательные файлы *f1* и *f2* сливаются в файл *f*, при этом одиночные элементы образуют упорядоченные пары.
3. Полученный файл *f* вновь обрабатывается, как указано в шагах 1 и 2. При этом упорядоченные пары переходят в упорядоченные четверки.
4. Повторяя шаги, сливаем четверки в восьмерки и т.д., каждый раз удваивая длину слитых последовательностей до тех пор, пока не будет упорядочен целиком весь файл.

После выполнения *i* проходов получаем два файла, состоящих из серий длины *2^i*. Окончание процесса происходит при выполнении условия *2^i >= n*. Следовательно, процесс сортировки простым слиянием требует порядка *O(log(n))* проходов по данным.

**Замечание:** При использовании метода прямого слияния не принимается во внимание то, что исходный файл может быть частично отсортированным, т.е. может содержать упорядоченные подпоследовательности записей.

![Схема выполнения сортировки прямым слиянием](https://intuit.ru/EDI/28_11_18_2/1543357168-6234/tutorial/909/objects/43/files/43_01.png)

Исходный и вспомогательные файлы будут ***O(log(n))*** раз прочитаны и столько же раз записаны.

**Сложность:** *O(n \* log(n))*.

#### Сортировка естественным слиянием (Natural merge sort)

В сравнении с методом прямого слияния, сортировка обладает некоторым преимуществом: учитывается тот факт, что могут содержаться упорядоченные подпоследовательности. То есть, ***длинна серии*** не ограничивается, а определяется количеством элементов в уже упорядоченных подпоследовательностях, выделяемых на каждом проходе.

***Алгоритм:***
1. Исходный файл *f* разбивается на два вспомогательных файла *f1* и *f2*. Распределение происходит следующим образом: поочередно считываются записи *ai* исходной последовательности (неупорядоченной) таким образом, что если значения ключей соседних записей удовлетворяют условию *f(ai) <= f(ai+1)*, то они записываются в первый вспомогательный файл *f1*. Как только встречаются *f(ai) > f(ai+1)*, то записи *ai+1* копируются во второй вспомогательный файл *f2*. Процедура повторяется до тех пор, пока все записи исходной последовательности не будут распределены по файлам.
2. Вспомогательные файлы *f1* и *f2* сливаются в файл *f*, при этом серии образуют упорядоченные последовательности.
3. Полученный файл *f* вновь обрабатывается, как указано в шагах *1* и *2*.
4. Повторяя шаги, сливаем упорядоченные серии до тех пор, пока не будет упорядочен целиком весь файл.

Естественное слияние, у которого после фазы распределения количество серий во вспомогательных файлах отличается друг от друга не более чем на единицу, называется ***сбалансированным слиянием***, в противном случае – ***несбалансированное слияние***.

![Пример естественного слияния. Изображение 1.](https://studref.com/htm/img/15/11119/81.png)
![Пример естественного слияния. Изображение 2.](https://studref.com/htm/img/15/11119/82.png)
![Пример естественного слияния. Изображение 3.](https://studref.com/htm/img/15/11119/84.png)
![Пример естественного слияния. Изображение 4.](https://studref.com/htm/img/15/11119/85.png)
![Пример естественного слияния. Изображение 5.](https://studref.com/htm/img/15/11119/86.png)
![Пример естественного слияния. Изображение 6.](https://studref.com/htm/img/15/11119/87.png)

Таким образом, число чтений или перезаписей файлов при использовании метода естественного слияния будет не хуже, чем при применении метода простого слияния, а в среднем – даже лучше. Но в этом методе увеличивается число сравнений за счет тех, которые требуются для распознавания концов серий. Помимо этого, максимальный размер вспомогательных файлов может быть близок к размеру исходного файла, так как длина серий может быть произвольной.

#### Сортировка многопутевым слиянием (Multi-Way merge sort)

Данный метод сортировки является модификацией метода естественного слияния. Временные затраты на любую сортировку последовательностей пропорциональны числу требуемых проходов, так как при каждом проходе копируются все данные. Чтобы уменьшить число этих проходов, серии распределяют на последовательности, число которых больше 2-х.

Слияние *Р* серий, поровну распределены в *М* последовательностей, дает в результате *Р / М* серий. Второй проход уменьшить это число до *Р / M^2*, третий - до *Р / M^3* и т.д. Поэтому общие число проходов многопутевого слияния будет равно *Log m (K)*, где *К* - число элементов в последовательности. Итак, в этом методе, по сравнению с методом естественно слияния, добавляются *М* путей распределения и слияния последовательностей.

Рассмотрим в качестве примера сортировку трехпутевым слиянием следующей последовательности:
![Пример многопутевого слияния. Изображение 1.](https://studref.com/htm/img/15/11119/88.png)
![Пример многопутевого слияния. Изображение 2.](https://studref.com/htm/img/15/11119/89.png)
![Пример многопутевого слияния. Изображение 3.](https://studref.com/htm/img/15/11119/90.png)
![Пример многопутевого слияния. Изображение 4.](https://studref.com/htm/img/15/11119/91.png)
![Пример многопутевого слияния. Изображение 5.](https://studref.com/htm/img/15/11119/92.png)
![Пример многопутевого слияния. Изображение 6.](https://studref.com/htm/img/15/11119/93.png)
![Пример многопутевого слияния. Изображение 7.](https://studref.com/htm/img/15/11119/94.png)
![Пример многопутевого слияния. Изображение 8.](https://studref.com/htm/img/15/11119/95.png)
![Пример многопутевого слияния. Изображение 9.](https://studref.com/htm/img/15/11119/96.png)
![Пример многопутевого слияния. Изображение 10.](https://studref.com/htm/img/15/11119/97.png)

Рассмотренный пример показывает, что алгоритм многопутевого (естественного) слияния работает эффективнее, чем рассмотренные ранее алгоритмы прямого и естественного слияния. Так, при трехпутевом слиянии для сортировки указанной последовательности потребовалось только три прохода, в то время как для естественного и прямого слияния потребовалось бы четыре и пять проходов соответственно.

Дополнительно: https://intuit.ru/studies/courses/648/504/lecture/11473, https://studref.com/701956/informatika/estestvennoe_sliyanie, https://studfile.net/preview/930712/page:7, https://studref.com/701957/informatika/mnogoputevaya_sortirovka, https://www.geeksforgeeks.org/external-sorting, https://josef.codes/sorting-really-large-files-with-c-sharp

### [Реализация (C# пример)](./algForExam/ExternalSortExtensions.cs)

#### Сортировка прямым слиянием
```cs
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
```

#### Сортировка естественным слиянием
```cs
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
```

#### Сортировка многопутевым (прямым) слиянием
```cs
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
```

## Билет 9: Сортировка с помощью двоичного дерева (Tree Sort)

### Описание
Алгоритм сортировки, основанный на структуре данных [**двоичное дерево поиска**](#двоичное-дерево-поиска). Сначала он создаёт двоичное дерево поиска из элементов входного списка или массива, а затем выполняет обход созданного двоичного дерева поиска по порядку, чтобы получить элементы в отсортированном порядке.

***Алгоритм:***
1. Возьмите элементы, введенные в массив.
2. Создайте двоичное дерево поиска, вставив элементы данных из массива в двоичное дерево поиска.
3. Выполните обход дерева по порядку, чтобы получить элементы в отсортированном порядке.

**Сложность:**
- <u>Средний случай:</u> *O(n \* log(n))*, добавление одного элемента в дерево двоичного поиска в среднем занимает *O(log(n))* времени. Следовательно, добавление *n* элементов займет *O(n \* log(n))* времени;
- <u>Худший случай:</u> *O(n^2)*, может быть улучшена с помощью самобалансирующегося двоичного дерева поиска;

**Вспомогательное пространство:** *O(n)*.

#### Двоичное дерево поиска
Структура данных двоичного дерева на основе узлов, которая обладает следующими свойствами:
- *Левое поддерево узла содержит только узлы с ключами меньше, чем ключ узла.*
- *Правое поддерево узла содержит только узлы с ключами больше, чем ключ узла.*
- *Каждое из левого и правого поддеревьев также должно быть бинарным деревом поиска.*

##### Поиск

***Алгоритм:***
1. Начните с корня.
2. Сравните искомый элемент с корнем, если он меньше корня, то рекурсивно вызовите левое поддерево, иначе рекурсивно вызовите правое поддерево.
3. Если элемент для поиска найден где угодно, верните true, иначе верните false.

**Временная ложность:** *O(h)*, **Пространственная сложность:** *O(h)*, где *h* — высота бинарного дерева поиска.

##### Вставка

***Алгоритм:***
1. Начните с корня. 
2. Сравните вставляемый элемент с корнем, если он меньше корня, то рекурсивно вызовите левое поддерево, иначе рекурсивно вызовите правое поддерево. 
3. Достигнув конца, просто вставьте этот узел слева (если он меньше текущего) или справа. 

**Временная ложность:** *O(h)*, где *h* — высота бинарного дерева поиска, **Вспомогательное пространство:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/binary-search-tree-set-1-search-and-insertion, https://www.geeksforgeeks.org/tree-sort, https://www.programiz.com/dsa/binary-tree, https://intuit.ru/studies/courses/648/504/lecture/11472

### [Реализация (C# пример)](./algForExam/TreeSortExtensions.cs)

```cs
public class Node<T> where T : IComparable
{
    public T Value { get; set; }

    public Node<T>? Left { get; private set; }

    public Node<T>? Right { get; private set; }

    public Node(T value)
    {
        Value = value;
    }

    public void Insert(T value)
    {
        if (Value.CompareTo(value) > 0) // Сортировка по возрастанию
        {
            if (Left == null)
            {
                Left = new Node<T>(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            if (Right == null)
            {
                Right = new Node<T>(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    public IList<T> ToList(IList<T>? collection = null)
    {
        var index = 0;
        return ToList(ref index, collection);
    }

    private IList<T> ToList(ref int index, IList<T>? collection = null)
    {
        collection ??= new List<T>();

        Left?.ToList(ref index, collection);

        collection[index++] = Value;

        Right?.ToList(ref index, collection);

        return collection;
    }
}

public static IList<T> TreeSort<T>(this IList<T> collection) where T : IComparable
{
    if (collection.Count > 0)
    {
        var node = new Node<T>(collection[0]);
        for (var i = 1; i < collection.Count; i++)
        {
            node.Insert(collection[i]);
        }

        node.ToList(collection);
    }

    return collection;
}
```

## Билет 10: Поразрядная сортировка (Radix Sort)

### Описание
Алгоритм, который сортирует элементы, сначала группируя отдельные цифры одного и того-же разряда. Затем сортирует элементы в порядке возрастания/убывания.

Идея сортировки по основанию состоит в том, чтобы выполнять сортировку по цифрам, начиная с младшей значащей цифры и заканчивая старшей значащей цифрой. Сортировка по основанию использует **[сортировку подсчетом](#сортировка-подсчётом)** в качестве подпрограммы для сортировки.

***Алгоритм:***
1. Найдите самый большой элемент в массиве, т.е. *max*. Пусть *X* будет количество цифр в *max*. *X* вычисляется, потому что мы должны пройти все значимые места всех элементов.
2. Теперь пройдитесь по каждому значимому месту одно за другим. Отсортируйте элементы по цифрам разряда.

**Сложность:**
- <u>Лучший случай:</u> *O(n + k)*;
- <u>Средний случай:</u> *O(n + k)*;
- <u>Худший случай:</u> *O(n + k)*;

**Вспомогательное пространство:** *O(max)*;

#### Сортировка подсчётом

Алгоритм сортировки, который сортирует элементы массива, подсчитывая количество вхождений каждого уникального элемента в массиве. Счетчик хранится во вспомогательном массиве, а сортировка выполняется путем отображения счетчика как индекса вспомогательного массива.

***Алгоритм:***
1. Найдите максимальный элемент (пусть это будет *max*) из заданного массива.
2. Инициализировать массив длины *max + 1*. Этот массив используется для хранения количества элементов в массиве.
3. Сохраните количество каждого элемента в соответствующем индексе в *count* массиве.
4. Храните кумулятивную сумму элементов массива count. Это помогает поместить элементы в правильный индекс отсортированного массива.
5. Найдите индекс каждого элемента исходного массива в массиве count. Это дает кумулятивный счет.
6. После размещения каждого элемента в правильном месте уменьшите его количество на единицу.

**Сложность:**
- <u>Лучший случай:</u> *O(n + k)*;
- <u>Средний случай:</u> *O(n + k)*;
- <u>Худший случай:</u> *O(n + k)*;

**Вспомогательное пространство:** *O(max)*;

Дополнительно: https://www.geeksforgeeks.org/radix-sort, https://www.programiz.com/dsa/radix-sort, https://www.programiz.com/dsa/counting-sort

### [Реализация (C# пример)](./algForExam/RadixSortExtensions.cs)
```cs
public static IList<int> RadixSort(this IList<int> collection)
{
    var maxValue = collection.Max();

    for (var exponent = 1; maxValue / exponent > 0; exponent *= 10)
    {
        collection.CountingSort(exponent);
    }

    return collection;
}

public static IList<int> CountingSort(this IList<int> collection, int exponent)
{
    var outputArr = new int[collection.Count];
    var countArr = new int[10];

    foreach (var item in collection) // Считаем количество вхождений каждого элемента массива
    {
        countArr[(item / exponent) % 10]++;
    }

    for (var i = 1; i < 10; i++) // Сохраняем фактические позиции элементов
    {
        countArr[i] += countArr[i - 1];
    }

    for (var i = collection.Count - 1; i >= 0; i--) // Устанавливаем элементы в отсортированные позиции
    {
        outputArr[countArr[(collection[i] / exponent) % 10] - 1] = collection[i];
        countArr[(collection[i] / exponent) % 10]--;
    }

    for (var i = 0; i < collection.Count; i++) // Копируем элементы в исходный массив
    {
        collection[i] = outputArr[i];
    }

    return collection;
}
```

## Билет 11: Хэш-таблицы с разрешением коллизий методом цепочек

### Описание
В хеш-таблице новый индекс обрабатывается с помощью ключей. Элемент, соответствующий этому ключу, сохраняется в индекс. Этот процесс, называется хешированием. Хорошая хеш-функция предполагает достаточно быстрое вычисление, сводит к минимуму число коллизий.

Идей цепочек состоит в том, чтобы реализовать массив, как связный список, называемый цепочкой. Это один из самых популярных и часто используемых методов обработки коллизий. 
Когда возникает ситуация, что несколько элементов хэшируются в один и тот же индекс слота, затем эти элементы вставляются в односвязный список, известный как цепочка. Теперь мы можем использовать ключ K для поиска в связном списке, просто просматривая его линейно. Если внутренний ключ для какой-то записи совпадёт с ключом K, это будет означать, что мы нашли нашу запись. В случае, если мы достигли конца связного списка, но не нашли нашу запись, то это будет означать, что запись не существует. ***Вывод:*** если в отдельной цепочке два разных элемента имеют одинаковое значение хеш-функции, мы сохраняем оба элемента в одном и том же связном списке один за другим.

**Производительность цепочек:**
Производительность хеширования можно оценить в предположении, что каждый ключ с одинаковой вероятностью будет хэширован в любой слот таблицы (просто равномерное хеширование).
- m - количество слотов в хеш-таблице;
- n - количество вставленных значений в хеш-таблицу;
- Коэффициент загрузки: *α = n / m*;
- Ожидаемое время поиска: *O(1 + α)*;
- Ожидаемое время удаления: *O(1 + α)*;
- Время на вставку: *O(1)*;
- Сложность поиска, вставки и удаления ровна *O(1)*, если *α = O(1)*.

Дополнительно: https://www.geeksforgeeks.org/separate-chaining-collision-handling-technique-in-hashing, https://www.programiz.com/dsa/hash-table, https://iq.opengenus.org/time-complexity-of-hash-table

### [Реализация (C# пример)](./algForExam/Dictionary.cs)
```cs
/// <summary> Словарь: хеш-таблица, разрешение коллизий методом цепочек </summary>
/// <typeparam name="TKey"> Тип ключа </typeparam>
/// <typeparam name="TValue"> Тип значения </typeparam>
public class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue?>>
{
    private readonly int _size;

    public double FillFactor => (double)Count / _size;

    public int MaxLengthChain => _items.Max(x => x?.Count ?? 0);

    public int MinLengthChain => _items.Min(x => x?.Count ?? 0);

    public IEnumerable<int> LengthsChains => _items.Select(x => x?.Count ?? 0);

    public int Count { get; private set; }

    private readonly LinkedList<KeyValuePair<TKey, TValue?>>?[] _items;

    public Dictionary(int size = 1000)
    {
        if (!IsSizeCorrect(size)) throw new AggregateException(nameof(size));
        _size = size;
        _items = new LinkedList<KeyValuePair<TKey, TValue?>>[size];
    }

    public void Add(TKey key, TValue value)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        var item = new KeyValuePair<TKey, TValue?>(key, value);
        Insert(item);
    }

    protected void Insert(KeyValuePair<TKey, TValue?> item)
    {
        var position = GetListPosition(item.Key);
        var linkedList = GetLinkedList(position);

        foreach (var pair in linkedList)
        {
            if (pair.Key != null && pair.Key.Equals(item.Key))
                throw new ArgumentException("Элемент по указанному ключу уже существует.");
        }

        linkedList.AddLast(item);
        Count++;
    }

    protected bool IsSizeCorrect(int size)
    {
        return size > 0;
    }

    public bool Remove(TKey key)
    {
        var position = GetListPosition(key);
        var linkedList = GetLinkedList(position);
        var itemFound = false;
        var foundItem = default(KeyValuePair<TKey, TValue?>);
        foreach (var item in linkedList)
        {
            if (item.Key != null && item.Key.Equals(key))
            {
                itemFound = true;
                foundItem = item;
            }
        }

        if (itemFound)
        {
            linkedList.Remove(foundItem);
            Count--;
        }
        return itemFound;
    }

    public bool ContainsKey(TKey key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        var position = GetListPosition(key);
        var linkedList = GetLinkedList(position);

        var foundItem = false;
        foreach (var item in linkedList)
        {
            if (item.Key != null && item.Key.Equals(key))
            {
                foundItem = true;
                break;
            }
        }

        return foundItem;
    }

    public TValue? GetValue(TKey key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        var position = GetListPosition(key);
        var linkedList = GetLinkedList(position);
        foreach (var item in linkedList)
        {
            if (item.Key != null && item.Key.Equals(key)) return item.Value;
        }

        return default;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var t = GetValue(key);
        value = t;
        return t != null;
    }

    protected int GetListPosition(TKey key)
    {

        return Math.Abs(key.GetHashCode() % _size); // Метод деления

        // Метод умножения
        // var goldenRatioConst = (Math.Sqrt(5) - 1) / 2;
        // return (int) Math.Abs(_size * (key.GetHashCode() * goldenRatioConst % 1));
    }

    protected LinkedList<KeyValuePair<TKey, TValue?>> GetLinkedList(int position)
    {
        var linkedList = _items[position];
        if (linkedList == null)
        {
            linkedList = new LinkedList<KeyValuePair<TKey, TValue?>>();
            _items[position] = linkedList;
        }

        return linkedList;
    }

    public void Clear()
    {
        if (Count > 0)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                _items[i] = null;
            }
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue?>> GetEnumerator()
    {
        foreach (var linkedList in _items)
        {
            if (linkedList != null)
            {
                foreach (var keyValuePair in linkedList)
                {
                    yield return keyValuePair;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

## Билет 12: Хэш-таблицы с разрешением коллизий методом открытой адресации

### Описание
Подобно методу цепочек, открытая адресация является методом обработки коллизий. В открытой адресации все элементы хранятся в самой хеш-таблице. Таким образом, в любой момент размер таблицы должен быть больше или равен общему количеству ключей (обратите внимание, что мы можем увеличить размер таблицы, скопировав старые данные, если это необходимо). Этот подход также известен как закрытое хеширование. Вся эта процедура основана на исследованиях: линейное, квадратичное, двойное.

**Преимущества перед методом цепочек:**
- Открытая адресация повышает скорость кэширования, поскольку все данные хранятся в хеш-таблице.
- Он правильно использует свои пустые индексы и повышает эффективность использования памяти.
- Поскольку не используется связанный список или указатель, производительность выше, чем при цепочке или открытом хешировании.

**Операции:**
- добавление элемента — продолжается поиск, пока не будет найден пустой слот, как только найден, вставляем k;
- поиск элемента — продолжать поиск пока ключ слота не станет равным k или пока не будет достигнут пустой слот; 
- удаление — есть нюансы, если мы просто удалим ключ, то поиск может не получиться, поэтому слоты удалённых ключей помечаются как удалённые, возможность вставить элемент в удалённый слот останется, но поиск на месте удалённого слота останавливаться не будет;

**Производительность открытой адресации:**
Подобно цепочке, производительность хеширования можно оценить, исходя из предположения, что каждый ключ с одинаковой вероятностью будет хэширован в любой слот таблицы (простое равномерное хеширование).
- m - количество слотов в хеш-таблице;
- n - количество вставленных значений в хеш-таблицу;
- Коэффициент загрузки: *α = n / m (< 1)*;
- Сложность поиска, вставки и удаления ровна *O(1 / (1 + α))*.

Дополнительно: https://www.geeksforgeeks.org/open-addressing-collision-handling-technique-in-hashing, https://www.programiz.com/dsa/hash-table, https://iq.opengenus.org/time-complexity-of-hash-table

### [Реализация (C# пример)](./algForExam/Hashtable.cs)
```cs
/// <summary> Хеш-таблица, разрешение коллизий методом открытой адресации </summary>
/// <typeparam name="TKey"> Тип ключа </typeparam>
/// <typeparam name="TValue"> Тип значения </typeparam>
public class Hashtable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue?>>
{
    private readonly int _size;

    private readonly KeyValuePair<TKey, TValue?>[] _items;

    private readonly bool[] _removed;

    private static readonly Func<Func<object, int, int>, object, int, int, int> LinearHashing =
        (f, key, sizeHashTable, index) => (f(key, sizeHashTable) + index) % sizeHashTable;

    private static readonly Func<Func<object, int, int>, object, int, int, int> QuadraticHashing =
        (f, key, sizeHashTable, index) => (f(key, sizeHashTable) + (int)Math.Pow(index, 2)) % sizeHashTable;

    private static readonly Func<Func<object, int, int>, Func<object, int, int>, object, int, int, int> DoubleHashing =
        (f1, f2, key, sizeHashTable, index) => (f1(key, sizeHashTable) + index * f2(key, sizeHashTable)) % sizeHashTable;

    public int Count { get; private set; }

    public int MaxClusterLength
    {
        get
        {
            var max = 0;
            var current = 0;
            foreach (var item in _items)
            {
                if (!item.Equals(default(KeyValuePair<TKey, TValue?>)))
                {
                    current++;
                }
                else
                {
                    max = Math.Max(max, current);
                    current = 0;
                }
            }

            return Math.Max(max, current);
        }
    }

    public Hashtable(int size = 1000)
    {
        if (!IsSizeCorrect(size)) throw new AggregateException(nameof(size));
        _size = size;
        _items = new KeyValuePair<TKey, TValue?>[size];
        _removed = new bool[_size];
    }

    protected bool CheckOpenSpace()
    {
        var isOpen = false;
        for (var i = 0; i < _size; i++)
        {
            if (_items[i].Equals(default(KeyValuePair<TKey, TValue?>))) isOpen = true;
        }

        return isOpen;
    }

    protected bool IsSizeCorrect(int size)
    {
        return size > 0;
    }

    protected bool CheckUniqueKey(TKey key)
    {
        foreach (var item in _items)
        {
            if (item.Key != null && item.Key.Equals(key)) return false;
        }

        return true;
    }

    public void Add(TKey key, TValue value)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));

        if (!CheckOpenSpace()) throw new ArgumentOutOfRangeException("Хеш-таблица переполнена.");

        if (!CheckUniqueKey(key)) throw new ArgumentException("Элемент по указанному ключу уже существует.");

        Insert(key, value);
    }

    protected void Insert(TKey key, TValue value)
    {
        var index = 0;
        var hashCode = GetHash(key, index);

        while (!_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)) && !_items[hashCode].Key.Equals(key))
        {
            index++;
            hashCode = GetHash(key, index);
        }

        _items[hashCode] = new KeyValuePair<TKey, TValue?>(key, value);
        _removed[hashCode] = false;
        Count++;
    }

    protected int GetHash(TKey key, int index)
    {
        // Линейный анализ, вспомогательная функция — метод деления.
        return LinearHashing((key, sizeHashTable) => Math.Abs(key.GetHashCode() % sizeHashTable), key, _size, index);
    }

    public TValue? GetValue(TKey key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));

        var index = 0;
        var hashCode = GetHash(key, index);

        while ((!_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)) || _removed[hashCode]) && !_items[hashCode].Key.Equals(key))
        {
            index++;
            hashCode = GetHash(key, index);
        }

        return _items[hashCode].Value;
    }

    public bool Remove(TKey key)
    {
        var index = 0;
        var hashCode = GetHash(key, index);

        while ((!_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)) || _removed[hashCode]) && !_items[hashCode].Key.Equals(key))
        {
            index++;
            hashCode = GetHash(key, index);
        }

        if (_items[hashCode].Equals(default(KeyValuePair<TKey, TValue>)))
        {
            return false;
        }
        else
        {
            _items[hashCode] = default;
            _removed[hashCode] = true;
            Count--;
            return true;
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue?>> GetEnumerator()
    {
        foreach (var keyValuePair in _items)
        {
            if (!keyValuePair.Equals(default(KeyValuePair<TKey, TValue?>)))
            {
                yield return keyValuePair;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

## Билет 13: ABC сортировка для строк (Allen Beechick Character Sort for string)

### Описание
Лексографическая вариация поразрядной MSD (по наибольшей значащей цифре) сортировки. Автор Аллен Бичик выбрал название в честь себя любимого, ABCsort расшифровывается как Allen Beechick Character sort. Сам по себе Бичик примечателен тем, что он не только программист, а ещё и целый магистр богословия.

Для сортировки требуется два вспомогательных массива.

Один из них назовём трекер слов (WT – word tracker), с помощью него мы будем группировать слова, имеющих одинаковые буквы в i-м разряде. Для самого первого найденного такого слова в списке заносится значение 0. Для каждого последующего найденного слова с той же буквой в i-м разряде в трекере слов отмечается индекс предыдущего слова, соответствующего этому же признаку.
![Трекер слов. Изображение 1.](https://habrastorage.org/r/w1560/getpro/habr/post_images/1aa/247/736/1aa247736af37cd4f09016f37d58beea.png)

Ещё один массив – трекер символов (LT – letter tracker). В нём отмечаются индексы самого первого (или последнего) слова в списке, в котором в соответствующем разряде находится определённый символ. Отталкиваясь от этого слова, с помощью трекера слов восстанавливается цепочка всех остальных лексем, имеющих в i-м разряде соответствующую букву.
![Трекер символов. Изображение 2.](https://habrastorage.org/r/w1560/getpro/habr/post_images/bd1/c6f/06a/bd1c6f06a50f27443d411ab1abb33e02.png)

Создавая и прослеживая подобные цепочки слов, рекурсивно продвигаясь от старших разрядов к младшим, в итоге весьма быстро формируются новые последовательности, упорядоченные в алфавитном порядке. Отсортировав слова на «A», затем сортируется «B», затем «C» и далее по алфавиту.
![Демонстрация работы алгоритма. Изображение 3.](https://habrastorage.org/getpro/habr/post_images/8f8/fba/5df/8f8fba5df90727ad721be8b081f9da3c.gif)

**Сложность:** *O(k * n)*, где *k* —  количество обрабатываемых разрядов.

**Вспомогательное пространство:** *O(n)*.

Дополнительно: https://habr.com/ru/post/201534/, http://www.aislebyaisle.com/cb/access/sorting/beechicksort.htm, http://algolab.valemak.com/radix

### [Реализация (C# пример)](./algForExam/ABCSortExtensions.cs)
```cs
private static IList<string> ABCSort(this IList<string> collection, int rank)
{
    if (collection.Count < 2) return collection;

    var table = new System.Collections.Generic.Dictionary<char, IList<string>>(); // key - символ в позиции rank, список слов с символом key в позиции rank
    var listResult = new List<string>();
    var shortWordsCounter = 0;

    foreach (var str in collection)
    {
        if (rank < str.Length)
        {
            if (table.ContainsKey(str[rank]))
            {
                table[str[rank]].Add(str);
            }
            else
            {
                table.Add(str[rank], new List<string> {str});
            }
        }
        else
        {
            listResult.Add(str);
            shortWordsCounter++;
        }
    }

    if (shortWordsCounter == collection.Count) return collection;

    for (var i = 'A'; i <= 'z'; i++)
    {
        if (table.ContainsKey(i))
        {
            foreach (var str in ABCSort(table[i], rank + 1))
            {
                listResult.Add(str);
            }
        }
    }

    return listResult;
}
```

## Билет 14: Реализовать стек и базовые операции работы со стеком, с использованием собственного двусвязного списка

### Описание
**Стек** — это линейная структура данных, которая следует принципу «последним пришел — первым вышел» (LIFO). Это означает, что последний элемент, вставленный в стек, удаляется первым.

**Операции:**
- ***Push*** — операция добавления элемента на вершину стека;
- ***Pop*** — извлечение элемента с вершины стека;
- ***IsEmpty*** — проверка, пуст ли стек;
- ***Peek*** — получить значение верхнего элемента, не удаляя его;

**Сложность операций:** *O(1)*.

Дополнительно: https://www.geeksforgeeks.org/implement-a-stack-using-singly-linked-list, https://www.geeksforgeeks.org/c-sharp-stack-with-examples, https://www.programiz.com/dsa/stack, https://www.programiz.com/csharp-programming/stack

### [Реализация (C# пример)](./algForExam/Stack.cs)
```cs
public class Stack<T> : IReadOnlyCollection<T>
{
    private class Node<T>
    {
        public T Value { get; }

        public Node<T> Top { get; init; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node<T>? _top;

    public int Count { get; private set; }

    public void Push(T element)
    {
        var newNode = new Node<T>(element)
        {
            Top = _top
        };
        _top = newNode;
        Count++;
    }

    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Стек пуст, нельзя извлечь элемент.");

        var elem = _top.Value;
        _top = _top.Top;
        Count--;
        return elem;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Стек пуст, нельзя получить элемент.");

        return _top.Value;
    }

    public bool IsEmpty()
    {
        return _top == null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = _top;
        while (node != null)
        {
            yield return node.Value;
            node = node.Top;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```
