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
    q, quit, exit - Для выхода из программы
____
***Регистр ввода не важен***
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

Features
--------
**Supported commands:**

    ls <path> - Browse directory files
    rm <path> - Deleting a directory (recursively) / file
    dir <path> - Catalog information
    mvdir <path1> <path2> - Moving / Renaming a Directory
    mvfile <path1> <path2> - Moving / Renaming a File
    cp <path1> <path2> - Copying a file / directory
    clear - Cleaning the console
    file <file> - Displaying information about a file
    mkdir <path> - Creating a directory
    q,quit,exit - To exit the program
---
>In the root directory of the program there is a file "config.cfg" in which you can set the initial directory
and the number of displayed directories on one page.
```CFG
lastDirectory = C:\Forgithub
pageCount = 10
```
____
>To go to the next page, you must specify the "-p" parameter
```C#
   ls C:\Users\User\Desktop -p 2
```
>This will display the 3rd page of your desktop directories.