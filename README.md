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

### [Реализация (C# пример)](./algForExam//ExternalSortExtensions.cs)

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
