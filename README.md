# Алгоритмы: Материалы для экзамена.

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

#### Схема разделения Ломуто:
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
