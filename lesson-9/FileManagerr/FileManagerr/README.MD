FileManager for GeekBrains
==========================

![FileManagerScreen](https://github.com/mrmorgano001/lessons-gb/blob/main/lesson-9/images/screnn.png)

Возможности
-----------
**Поддерживаемые команды:**

    ls <path> - Просмотр файлов каталога
    rm <path> - Удаление каталога(рекурсивно)/файла
    dir <path> - Информация о каталоге
    mvdir <path1> <path2> - Перемещение/переименование каталога
    mvfile <path1> <path2> - Перемещение/переименование файла
    cp <path1> <path2> - Копирование файла/каталога
    clear - Очистка консоли
    file <file> - Вывод информации о файле
    mkdir <path> - Создание каталога
____

>В корневом каталоге программы имеется файл "config.cfg" в котором можно задать начальную директорию
и количество отображаемых каталогов на одной странице.
```CFG
lastDirectory = C:\Forgithub
pageCount = 10
```
____
>Для перехода на следующую страницу необходимо указывать параметр "-p"
```C#
   ls C:\Users\User\Desktop -p 2
```
>Таким образом отобразится 3-я страница каталогов вашего рабочего стола.

<h2>Features</h2>
This software features a console filegame function.
<br><b>Supported commands:</b>
<br>─ <b>ls &lt;path&gt;</b> - Browse directory files
<br>─ <b>rm &lt;path&gt;</b> - Deleting a directory (recursively) / file
<br>─ <b>dir &lt;path&gt;</b> - Catalog information
<br>─ <b>mvdir &lt;path1&gt; path2&gt;</b> - Moving / Renaming a Directory
<br>─ <b>mvfile &lt;path1&gt; path2&gt;</b> - Moving / Renaming a File
<br>─ <b>cp &lt;path1&gt; path2&gt;</b> - Copying a file / directory
<br>─ <b>clear</b> - Cleaning the console
<br>─ <b>file &lt;file&gt;</b> - Displaying information about a file
<br>─ <b>mkdir &lt;path&gt;</b> - Creating a directory
