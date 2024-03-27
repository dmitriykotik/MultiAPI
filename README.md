# MultiAPI - [![GitHub](https://img.shields.io/badge/GitHub-MultiAPI-blue?labelColor=gray&style=flat&link=https://github.com/dmitriykotik/MultiAPI)](https://github.com/dmitriykotik/MultiAPI) [![NuGet](https://img.shields.io/badge/NuGet-v0.1.1-orange?labelColor=gray&style=flat&link=https://www.nuget.org/packages/MultiAPI_Lib)](https://www.nuget.org/packages/MultiAPI_Lib) [![MultiAPI](https://img.shields.io/badge/v0.1.1-not%20stable-red?labelColor=gray&style=flat)]() [![License](https://img.shields.io/badge/License-GPL--3.0-blue?labelColor=gray&style=flat)]()
MultiAPI - Это библиотека и сборка разного ПО (Далее "Библиотека") для разработчиков. Она содержит множество функций чтобы ускорить разработку ПО. Данная библиотека усовершенствованная версия библиотеки MultiLib. MultiAPI подойдёт как начинающим разработчикам, так и профессиональным разработчикам ПО.

**Если вам понравился данный проект, то поставьте пожалуйста звезду на проекте, на [![GitHub](https://img.shields.io/badge/GitHub-MultiAPI-blue?labelColor=gray&style=flat&link=https://github.com/dmitriykotik/MultiAPI)](https://github.com/dmitriykotik/MultiAPI). Спасибо <3**

При возникших вопросах или пожеланиях, вы можете написать на почту multiplayercorporation@gmail.com или создать запрос в **Issues**.

# Документация MultiAPI_Lib
## Введение
Выше в основном описание самой библиотеки. Библиотека и документация в основном нацелена на начинающих программистов, и на облегчение написания кода. Скорее всего найдутся люди с вопросами: "Чем она полезна для начинающих программистов?", "Чем она облегчает написание кода?". Я сам хочу знать ответы на данные вопросы. Библиотека просто существует. Возможно, она найдёт своё применение.

Для работы с библиотекой можно использовать любую среду разработки, но обязательно использовать .net framework версии не меньше 4.7.2!

> [!WARNING]
> В данный момент библиотека на этапе разработки, поэтому до версии ` 1.0.0.XXXX ` мы не обещаем полную совместимость старых функций в новых версиях.

> [!NOTE]
> В исходных кодах, в документации могут быть комментарии разработчика о том как работает код.

## Быстрый доступ
- [Введение](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#введение)
- [Импорт библиотеки в проект](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#импорт-библиотеки-в-проект)
  - [Ручной метод](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#ручной-метод)
  - [Использование командной строки NuGet](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#использование-командной-строки-nuget)
  - [Использование диспетчера пакетов NuGet](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#использование-диспетчера-пакетов-nuget)
  - [Импорт библиотеки](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#импорт-библиотеки)
- [Древо классов и методов](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#древо-классов-и-методов)
- [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

<space><space>
- [Main.cs - Basic](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#maincs---basic)
  - [rnd](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--rnd)
  - [terminate](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--terminate)
  - [getCurrentFolder](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--getcurrentfolder)
  - [writeMachine](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--writemachine)
- [FTP.cs - FTP](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#ftpcs---ftp)
  - [FTP](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--ftp)
  - [upload](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--upload)
  - [download](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--download)
  - [delete](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--delete)
  - [exists](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--exists)
- [Generator.cs - Generator](https://github.com/dmitriykotik/MultiAPI/blob/master/README.md#generatorcs---generator)
  - [GenPassword](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--genpassword)
- [INI.cs - INI](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#inics---ini)
  - [INI](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--ini)
  - [getValue](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--getvalue)
  - [setValue](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--setvalue)
  - [existsVariable](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--existsvariable)
  - [deleteVariable](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--deletevariable)
  - [deleteAllVariables](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--deleteallvariables)
- [Internet.cs - Internet](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#internetcs---internet)
  - [TestConnection](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--testconnection)
  - [ping](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--ping)
- [Mail.cs - Mail](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#mailcs---mail)
  - [send](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--send)
- [Music.cs - Music](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#musiccs---music)
  - [Music](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--music)
  - [play](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--play)
  - [stop](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--stop)
  - [pause](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--pause)
  - [setVolume](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--setvolume)
  - [getVolume](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--getvolume)
  - [getDuration](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--getduration)
  - [setPosition](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--setposition)
  - [getPosition](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--getposition)
  - [updatePath](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--updatepath)
  - [getPath](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#--getpath)
  - [repeat](https://github.com/dmitriykotik/MultiAPI/tree/master#--repeat)

## Импорт библиотеки в проект

> [!NOTE]
> Данный пункт для новичков и в примере используется Visual Studio 2022 с русским языком.

Установите библиотеку в проект.

> [!WARNING]
> Проект должен иметь версию .net Framework не меньше 4.7.2!

Библиотеку вы можете установить вручную, с помощью NuGet или с помощью диспетчера пакетов NuGet.

### Ручной метод
1. Скачайте стабильную версию библиотеки по этой [ссылке](https://github.com/dmitriykotik/MultiAPI/releases). 

Распознать стабильную версию можно по такому значку: [![MultiAPI](https://shields.io/badge/v0.0.0.0-Stable-green?labelColor=gray&style=flat)]()

Почти стабильная: [![MultiAPI](https://img.shields.io/badge/v0.0.0.0-n%20stable-yellow?labelColor=gray&style=flat)]()

Не стабильная: [![MultiAPI](https://shields.io/badge/v0.0.0.0-not%20stable-red?labelColor=gray&style=flat)]()

2. Откройте ваш проект.
3. В обозревателе решений найдите пункт "Ссылки".
4. Нажмите ПКМ по пункту "Ссылки" и выберите "Добавить ссылку...".
5. В открывшемся окне нажмите на кнопку "Обзор..." в правом нижнем углу.
6. Выберите скачанную библиотеку.
7. Перейдите во вкладку "Обзор" и поставьте там флажок для библиотеки MultiAPI_Lib.dll
   
- [x] MultiAPI_Lib.dll

### Использование коммандной строки NuGet
1. Откройте ваш проект.
2. Откройте командную строку NuGet (Средства -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов).
3. Введите в консоль следущую команду: ` Install-Package MultiAPI_Lib `, этим вы установите самую последнюю версию. Определённую версию вы можете найти на NuGet [![NuGet](https://img.shields.io/badge/NuGet-v0.1.1-orange?labelColor=gray&style=flat&link=https://www.nuget.org/packages/MultiAPI_Lib)](https://www.nuget.org/packages/MultiAPI_Lib)

### Использование диспетчера пакетов NuGet
1. Откройте ваш проект.
2. Откройте диспетчер пакетов NuGet (Средства -> Диспетчер пакетов NuGet -> Управление пакетами NuGet для решения...).
3. В поисковой строке введите MultiAPI_Lib и найдите пакет с абсолютно таким же названием, а автором ` dmitriykotik_off `.
4. Нажмите на пакет, в правом окне диспетчера выберите проекты в которые вам надо установить библиотеку, версию и нажмите кнопку установить.

### Импорт библиотеки
В проекте импортируйте библиотеку следующим образом:
```csharp
using MultiAPI;
```

## Древо классов и методов
``` text
.
└── MultiAPI_Lib
    ├── Main.cs - Basic
    │   ├── int rnd(int startInt, int endInt)
    │   ├── void terminate(int errorCode)
    │   ├── string getCurrentFolder()
    │   └── void writeMachine(string text, int countDown = 40, bool writeLine = true)
    ├── FTP.cs - FTP
    │   ├── FTP(string host, string userName, string password)
    │   ├── void upload(string localFullPath)
    │   ├── void download(string localPath)
    │   ├── void delete()
    │   └── bool exists()
    ├── Generator.cs - Generator
    │   ├── string GenPassword(int length)
    │   └── string GenPassword(int length, string dictionary)
    ├── INI.cs - INI
    │   ├── INI(string iniFile)
    │   ├── string getValue(string section, string variable)
    │   ├── void setValue(string section, string variable, string text)
    │   ├── bool existVariable(string section, string variable)
    │   ├── void deleteVariable(string section, string variable)
    │   └── void deleteAllVariables(string section)
    ├── Internet.cs - Internet
    │   ├── bool TestConnection()
    │   └── bool ping(string url)
    ├── Mail.cs - Mail
    │   └── void send(string fromEmail, string fromName, string toEmail, string subject, string textOrHtml, string smtpServer, int smtpPort, string smtpPasswordMail)
    ├── Music.cs - Music
    │   ├── Music(string pathFile, bool autoStart = false)
    │   ├── void play()
    │   ├── void stop()
    │   ├── void pause()
    │   ├── void setVolume(int volume)
    │   ├── int getVolume()
    │   ├── double getDuration()
    │   ├── void setPosition(double position)
    │   ├── double getPosition()
    │   ├── void updatePath(string pathFile)
    │   ├── string getPath()
    │   └── string repeat(bool turn)
    ├── RegEdit.cs - RegEdit
    │   ├── void create(RegistryKey key, string keyName)
    │   ├── void delete(RegistryKey key, string keyName)
    │   ├── void createVariable(RegistryKey key, string keyName, string varName, object varValue)
    │   ├── object getValue(RegistryKey key, string keyName, string varName)
    │   ├── void deleteVariable(RegistryKey key, string keyName, string varName)
    │   ├── void editVariable(RegistryKey key, string keyName, string varName, object varValue)
    │   └── bool existsVariable(RegistryKey key, string keyName, string varName)
    ├── Zip.cs - Zip
    │   ├── void EncryptFile(string inputFile, string outputFile, string password, int BufferSize = 104576)
    │   ├── void DecryptFile(string inputFile, string outputFile, string password, int BufferSize = 104576)
    │   ├── void create(string pathFoler, string outputArchive)
    │   └── void unpacking(string pathArchive, string outputFolder)
    └── WinAPI.cs - WinAPI
        └── Window
            ├── enum WindowStyles : uint
            ├── enum WindowStylesEx : uint
            ├── enum ShowWindowCommands : int
            ├── IntPtr Create(WindowStylesEx windowStyleEx, WindowStyles windowStyle, string className, string windowName, int x, int y, int width, int height)
            ├── bool Show(IntPtr hWindow, ShowWindowCommands command)
            ├── IntPtr Find(string className, string windowName)
            ├── bool Destroy(IntPtr hWnd)
            ├── bool Move(IntPtr hWindow, int x, int y, int width, int height)
            ├── bool Update(IntPtr hWindow)
            └── bool SetText(IntPtr hWindow, string text)
```

## Исключения
В данном пункте расписаны исключения которые вручную создаются. Данный список вы можете использовать для дальнейшей обработки исключений. Все ручные исключения выводятся в формате строки ` string `. Как можно примерно обработать ручные исключения библиотеки расписано ниже списка.

> [!WARNING]
> Данный список используется для исключений которые лично выставлялись. При работе некоторых методов могут возникнуть и другие исключения.

```text
0x00001 - Промежуток времени равен нулю, что делает её бесполезной
0x00002 - Промежуток времени меньше или равен нулю
0x00003 - Поле или значение не может быть пустым
0x00004 - Указанного файла не существует
0x00005 - Нет подключения к интернету
0x00006 - Привышение установленного лимита
```
Возможная обработка (Пример):
```csharp
try
{
    MultiAPI.Basic.writeMachine("Я шишибочка! :D", 0); // Используем "writeMachine" и используем значение "0" в аргументе "countdown", что вызывает исключение с кодом "0x00001"
}
catch (Exception ex)
{
    if (ex.Message == "0x00001") MultiAPI.Basic.terminate(1); // Если текст исключения равен "0x00001", то закрываем программу с кодом ошибки 1
}
```

## Main.cs - Basic
В этом классе содержутся следущие методы: 
```csharp
int rnd(int startInt, int endInt);
void terminate(int errorCode);
string getCurrentFolder();
void writeMachine(string text, int countDown = 40, bool writeLine = true);
```

Код класса:
```csharp
public static class Basic
{
   public static int rnd(int startInt, int endInt) {...}

   public static void terminate(int errorCode) {...}

   public static string getCurrentFolder() {...}

   public static void writeMachine(string text, int countDown = 40, bool writeLine = true) {...}
}
```

### - rnd
```csharp
int rnd(int startInt, int endInt);
```

` startInt ` - Начальное значение

` endInt ` - Конечное значение

#### Возврат: 
Случайное значение от ` startInt ` до ` endInt `


#### Пример:
```csharp
int random;
random = MultiAPI.Basic.rnd(1,10);
```
```csharp
Console.WriteLine(MultiAPI.Basic.rnd(1, 10));
```

#### Описание: 
Метод выводит случайное значение от ` startInt ` до ` endInt `. 

#### Код:
```csharp
public static int rnd(int startInt, int endInt)
{
    Random rnd = new Random(); // Создаём рандомайзер
    return rnd.Next(startInt, endInt); // Генерируем случайное число от startInt до endInt и возвращаем его
}
```

### - terminate
```csharp
void terminate(int errorCode);
```

` errorCode ` - Код ошибки

#### Пример:
```csharp
MultiAPI.Basic.terminate(0);
```

#### Описание:
Метод завершает работу программы с определённым кодом ошибки

#### Код:
```csharp
public static void terminate(int errorCode) => Environment.Exit(errorCode); // Завершаем работу программы с определённым кодом ошибки. Использование "=>" уменьшает метод если используется лишь одна строка.
```

### - getCurrentFolder
```csharp
string getCurrentFolder();
```

#### Возврат: 
Путь до папки с программой


#### Пример:
```csharp
string path;
path = MultiAPI.Basic.getCurrentFolder();
```
```csharp
Console.WriteLine(MultiAPI.Basic.getCurrentFolder);
```

#### Описание:
Метод возвращает путь к папке с программой

#### Код:
```csharp
public static string getCurrentFolder() { return Environment.CurrentDirectory; } // Возвращает путь до папки с программой. Использование "{ }" в одной строке с выполнением одного действия уменьшает громосткость кода ради одного действия. Это почти как и "=>", но "=>" не работает с "return"
```

### - writeMachine
```csharp
void writeMachine(string text, int countDown = 40, bool writeLine = true);
```

` text ` - Текст для вывода

` countDown ` - Задержка между символами в миллисекундах (По умолчанию равно 40 миллисекунж)

` writeLine ` - После завершения печати, перевести курсор на новую строку? (По умолчанию равно true (Да))

#### Пример:
```csharp
MultiAPI.Basic.writeMachine("Hello World!");
```
```csharp
MultiAPI.Basic.writeMachine("Hello World!", 100);
```
```csharp
MultiAPI.Basic.writeMachine("Hello World!", 40, false);
```
> [!NOTE]
> Если вы указываете значение в ` countDown `, то строго указывайте натуральное число (больше 0)

#### Описание: 
Метод печатает в терминал символы из текста с определённой задержкой.

#### Исключения:
Исключения: ` 0x00001 ` и ` 0x00002 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public static void writeMachine(string text, int countDown = 40, bool writeLine = true)
{
    if (countDown == 0) throw new Exception("0x00001"); // Если "countdown" (задержка между символами) равна 0, то выдаём исключение с текстом "0x00001"
    else if (countDown < 0) throw new Exception("0x00002"); // или Если "countdown" меньше 0, то выдаём исключение с текстом "0x00002"
    foreach (char c in text) // Разбираем текст на буквы
    {
        Console.Write(c); // Выводим букву в терминал
        Thread.Sleep(countDown); // Ожидаем указанное время из countdown в миллисекундах, перед тем как продолжить
    }
    if (writeLine) Console.WriteLine(); // Если "writeLine" равен "true", то выводим новую строку (Или переводим курсор на новую строку)
}
```

## FTP.cs - FTP
В этом классе содержутся следущие методы: 
```csharp
FTP(string host, string userName, string password);
void upload(string localFullPath);
void download(string localPath);
void delete();
bool exists();
```

Код класса:
```csharp
public class FTP
{
    private string _host;
    private string _userName;
    private string _password;

    public FTP(string host, string userName, string password) {...}

    public void upload(string localFullPath) {...}

    public void download(string localPath) {...}

    public void delete() {...}

    public bool exists() {...}

}
```

### - FTP
```csharp
FTP(string host, string userName, string password);
```

` host ` - Путь до удалённого файла. Например: ftp://0.0.0.0:21/file.exmp

` userName ` - Имя пользователя для аутентификации

` password ` - Пароль для аутентификации

#### Пример:
```csharp
MultiAPI.FTP newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
```
```csharp
var newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
```

#### Описание:
Определяет переменные для дальнейшего соединения с FTP сервером

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public FTP(string host, string userName, string password)
{
    if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) throw new Exception("0x00003"); // Если "host" или "userName", или "password" равен пустоте, то выдаём исключение с текстом "0x00003"
    _host = host; // Устанавливаем значение для переменной "_host" в виде "host"
    _userName = userName; // Устанавливаем значение для переменной "_userName" в виде "userName"
    _password = password; // Устанавливаем значение для переменной "_password" в виде "password"
}
```

### - upload
```csharp
void upload(string localFullPath);
```

` localFullPath ` - Локальный путь до файла

#### Пример:
```csharp
MultiAPI.FTP newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
newFTP.upload("C:\\Folder\\newFile.txt");
```

#### Описание:
Отправляем файл на FTP сервер

#### Исключения:
Исключения: ` 0x00003 `, ` 0x00004 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void upload(string localFullPath)
{
    if (string.IsNullOrEmpty(localFullPath)) throw new Exception("0x00003"); // Если "localFullPath" пустой, то выдаём исключение "0x00003"
    if (!File.Exists(localFullPath)) throw new Exception("0x00004"); // Если файл по пути "localFullPath" не найден, то выдаём исключение "0x00004"

    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_host); // Создаём соединение с "_host"

    request.Method = WebRequestMethods.Ftp.UploadFile; // Устанавливаем метод запроса как загрузка файла
    request.Credentials = new NetworkCredential(_userName, _password); // Устанавливаем учетные данные для аутентификации на сервере
    request.UsePassive = true; // Устанавливаем пассивный режим для передачи данных
    request.UseBinary = true; // Устанавливаем бинарный режим передачи данных
    request.KeepAlive = false; // Отключаем поддержание активного соединения

    using (Stream inputStream = File.OpenRead(localFullPath)) // Открываем поток для чтения содержимого локального файла
    using (Stream outputStream = request.GetRequestStream()) // Получаем поток для записи данных на FTP сервер
    {
        byte[] buffer = new byte[1024]; // Создаем буфер для чтения файла порциями
        int bytesRead = 0; // Переменная для хранения количества считанных байт
        while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0) outputStream.Write(buffer, 0, bytesRead); // Пишем порцию данных в поток для записи на сервер
    }
}
```

### - download
```csharp
void download(string localPath);
```

` localPath ` - Путь до локального файла (Нового)

#### Пример:
```csharp
MultiAPI.FTP newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
newFTP.download("C:\\Folder\\file.exmp");
```

#### Описание:
Сохраняет файл с сервера в файл "localPath"

#### Исключения:
Исключения: ` 0x00004 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void download(string localPath)
{
    if (string.IsNullOrEmpty(localPath)) throw new Exception("0x00003"); // Если "localPath" пустой, то выдаём исключение "0x00003"
    using (WebClient client = new WebClient()) // Создаём WEB-клиент
    {
        client.Credentials = new NetworkCredential(_userName, _password); // Устанавливаем учетные данные для аутентификации на сервере
        client.DownloadFile(_host, localPath); // Скачиваем файл "_host" в файл "localPath"
    }
}
```

### - delete
```csharp
void delete();
```

#### Пример:
```csharp
MultiAPI.FTP newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
newFTP.delete();
```

#### Описание:
Удаляет файл с сервера

#### Код:
```csharp
public void delete()
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_host); // Создаём подключение у серверу
    request.Method = WebRequestMethods.Ftp.DeleteFile; // Устанавливаем метод запроса как удаление файла
    request.Credentials = new NetworkCredential(_userName, _password); // Устанавливаем учетные данные для аутентификации на сервере
    FtpWebResponse response = (FtpWebResponse)request.GetResponse(); // Получаем ответ от FTP сервера на запрос удаления файла
    response.Close(); // Закрываем ответ от сервера
}
```

### - exists
```csharp
bool exists();
```

#### Возврат:
` true ` или ` false `. ` true ` - если файл существует, ` false ` - если не существует.

#### Пример:
```csharp
MultiAPI.FTP newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
Console.WriteLine(newFTP.exists());
```
```csharp
MultiAPI.FTP newFTP = new MultiAPI.FTP("ftp://0.0.0.0:21/file.exmp", "root", "12345678");
bool fileExists = newFTP.exists();
```

#### Описание:
Проверяет, есть ли файл на сервере

#### Код:
```csharp
public bool exists()
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_host); // Создаем запрос к FTP серверу для получения даты и времени последней модификации файла
    request.Credentials = new NetworkCredential(_userName, _password); // Устанавливаем учетные данные для аутентификации на сервере
    request.Method = WebRequestMethods.Ftp.GetDateTimestamp; // Устанавливаем метод запроса как получение даты и времени последней модификации файла

    try { using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) return true; } // Если запрос к серверу выполнен успешно, возвращаем true
    catch (WebException ex) when (((FtpWebResponse)ex.Response).StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) { return false; } // Если в ходе запроса произошли какие либо ошибки, то возвращаем false
}
```

## Generator.cs - Generator
В этом классе содержутся следущие методы:
```csharp
string GenPassword(int length);
string GenPassword(int length, string dictionary);
```

### - GenPassword
```csharp
string GenPassword(int length);
```
```csharp
string GenPassword(int length, string dictionary);
```

` length ` - Длинна пароля
` dictionary ` - Список символов которые могут входить в пароль

#### Возврат:
Сгенерированный пароль

#### Пример:
```csharp
string password = MultiAPI.Generator.GenPassword(18);
```
```csharp
Console.WriteLine(MultiAPI.Generator.GenPassword(18));
```
```csharp
string password = GenPassword(18, "abcdefghijklmnopqrstyvwxyz123456789");
```
```csharp
Console.WriteLine(GenPassword(18, "abcdefghijklmnopqrstyvwxyz123456789"));
```

#### Описание: 
Генерирует пароль с указанной длинной и возможностью указания своего списка символов

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public static string GenPassword(int length)
{
    if (string.IsNullOrEmpty(Convert.ToString(length))) throw new Exception("0x00003"); // Если "length" пустой, то выдаём исключение "0x00003"

    const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@-+=%*&?$#"; // Стандартный словарь

    StringBuilder sb = new StringBuilder(); // Создаем объект StringBuilder для формирования пароля
    Random rnd = new Random(); // Создаем объект Random для генерации случайных чисел

    for (int i = 0; i < length; i++)
    {
        int index = rnd.Next(chars.Length); // Получаем случайный индекс символа из стандартного набора символов
        sb.Append(chars[index]); // Добавляем символ к паролю
    }
    return sb.ToString(); // Возвращаем итоговый пароль
}

public static string GenPassword(int length, string dictionary)
{
    if (string.IsNullOrEmpty(Convert.ToString(length)) || string.IsNullOrEmpty(dictionary)) throw new Exception("0x00003"); // Если "length" или "dictionary" пустой, то выдаём исключение "0x00003"
    StringBuilder sb = new StringBuilder(); // Создаем объект StringBuilder для формирования пароля
    Random rnd = new Random(); // Создаем объект Random для генерации случайных чисел

    for (int i = 0; i < length; i++)
    {
        int index = rnd.Next(dictionary.Length); // Получаем случайный индекс символа из пользовательского набора символов
        sb.Append(dictionary[index]); // Добавляем символ к паролю
    }
    return sb.ToString(); // Возвращаем итоговый пароль
}
```

## INI.cs - INI
В этом классе содержутся следущие методы:
```csharp
INI(string iniFile);
string getValue(string section, string variable);
void setValue(string section, string variable, string text);
bool existVariable(string section, string variable);
void deleteVariable(string section, string variable);
void deleteAllVariables(string section);
```

### - INI
```csharp
INI(string iniFile);
```

` iniFile ` - Путь к ini файлу

#### Пример:
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
```
```csharp
var ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
```

#### Описание:
Установка значения для переменной, для дальнейшего взаиможействия с INI файлом

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public INI(string iniFile)
{
    if (string.IsNullOrEmpty(iniFile)) throw new Exception("0x00003"); // Если "iniFile" пустой, то выдаём исключение "0x00003"
    if (!File.Exists(iniFile)) File.Create(iniFile).Close(); // Если файла "iniFile" не существует, то создаём его.
    _iniFile = iniFile; // Для "_iniFile" выставляем значение "iniFile"
}
```

### - getValue
```csharp
string getValue(string section, string variable);
```

` section ` - Секция

` variable ` - Переменная в секции

#### Возврат:
Значение переменной ` variable ` из секции ` section `

#### Пример:
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
ini.getValue("NewSection", "FirstVar");
```
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
Console.WriteLine(ini.getValue("NewSection", "FirstVar"));
```

#### Описание:
Получает значение из переменной в секции

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public string getValue(string section, string variable)
{
    if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable)) throw new Exception("0x00003"); // Если "section" или "variable" пуст, то выдаём исключение "0x00003"
    FileIniDataParser parser = new FileIniDataParser(); // Создаём парсер
    IniData data = parser.ReadFile(_iniFile); // Читаем файл с помощью парсера
    return data[section][variable]; // Возвращаем значение переменной
}
```

### - setValue
```csharp
void setValue(string section, string variable, string text);
```

` section ` - Секция

` variable ` - Переменная в секции

` text ` - Текст

#### Пример:
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
ini.setValue("NewSection", "FirstVar", "FirstTextttttt");
```

#### Описание:
Устанавливаем значение в переменной из секции

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void setValue(string section, string variable, string text)
{
    if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable) || string.IsNullOrEmpty(text)) throw new Exception("0x00003"); // Если "section", "variable" или "text" пуст, то выдаём исключение "0x00003"
    FileIniDataParser parser = new FileIniDataParser(); // Создаём парсер
    IniData data = parser.ReadFile(_iniFile); // Читаем файл с помощью парсера
    data[section][variable] = text; // Пишем новый текст для переменной
    parser.WriteFile(_iniFile, data); // Записываем в файл новый текст для переменной
}
```

### - existsVariable
```csharp
bool existVariable(string section, string variable);
```

` section ` - Секция

` variable ` - Переменная в секции

#### Возврат:
` true ` или ` false `. ` true ` - если переменная существует, ` false ` - если не существует

#### Пример:
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
ini.existsVariable("NewSection", "FirstVar");
```
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
Console.WriteLine(ini.existsVariable("NewSection", "FirstVar"));
```

#### Описание:
Проверяет, есть ли переменная в секции

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public bool existVariable(string section, string variable)
{
    if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable)) throw new Exception("0x00003"); // Если "section" или "variable" пуст, то выдаём исключение "0x00003" 
    FileIniDataParser parser = new FileIniDataParser(); // Создаём парсер
    IniData data = parser.ReadFile(_iniFile); // Читаем файл с помощью парсера
    return data[section].ContainsKey(variable); // Возвращаем "true" или "false", если есть переменная
}
```

### - deleteVariable
```csharp
void deleteVariable(string section, string variable);
```

` section ` - Секция

` variable ` - Переменная в секции

#### Пример:
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
ini.deleteVariable("NewSection", "FirstVar");
```

#### Описание:
Удаляет переменную в секции

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void deleteVariable(string section, string variable)
{
    if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable)) throw new Exception("0x00003"); // Если "section" или "variable" пуст, то выдаём исключение "0x00003" 
    FileIniDataParser parser = new FileIniDataParser(); // Создаём парсер
    IniData data = parser.ReadFile(_iniFile); // Читаем файл с помощью парсера
    data[section].RemoveKey(variable); // Удаляем переменную
    parser.WriteFile(_iniFile, data); // Записываем действие в файл (Удаляем переменную в файле)
}
```

### - deleteAllVariables
```csharp
void deleteAllVariables(string section);
```

` section ` - Секция

#### Пример:
```csharp
MultiAPI.INI ini = new MultiAPI.INI("C:\\Folder\\iniFile.ini");
ini.deleteAllVariables("NewSection");
```

#### Описание:
Удаляем все переменные из секции

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void deleteAllVariables(string section)
{
    if (string.IsNullOrEmpty(section)) throw new Exception("0x00003"); // Если "section" пуст, то выдаём исключение "0x00003" 
    FileIniDataParser parser = new FileIniDataParser(); // Создаём парсер
    IniData data = parser.ReadFile(_iniFile); // Читаем файл с помощью парсера
    data[section].RemoveAllKeys(); // Удаляем все переменные из секции
    parser.WriteFile(_iniFile, data); // Записываем действие в файл (Удаляем все переменные в файле)
}
```

## Internet.cs - Internet
В этом классе содержутся следущие методы:
```csharp
bool TestConnection();
bool ping(string url);
```

### - TestConnection
```csharp
bool TestConnection();
```

#### Возврат:
Возвращает ` true `, если соединение с Интернетом установлено, иначе ` false `.

#### Пример:
```csharp
bool isConnected = MultiAPI.Internet.TestConnection();

if (isConnected) Console.WriteLine("Connection established.");
else Console.WriteLine("Unable to establish connection.");
```

#### Описание:
Проверяет наличие соединения с Интернетом путем отправки запроса на ping хоста "google.com".

#### Код:
```csharp
public static bool TestConnection()
{
    try
    {
        using (var ping = new Ping()) // Создаем экземпляр класса Ping с помощью using, чтобы гарантировать освобождение ресурсов
        {
            var result = ping.Send("google.com", 1000); // Посылаем пинг на google.com с таймаутом 1000 миллисекунд
            return result.Status == IPStatus.Success; // Возвращаем true, если ответ получен успешно, иначе false
        }
    }
    catch { return false; } // Если произошла ошибка во время пинга, возвращаем false
}

```

### - ping
```csharp
bool ping(string url);
```

` url ` - Адрес для проверки доступности

#### Возврат:
Возвращает ` true `, если удалось установить соединение с указанным адресом, иначе ` false `

#### Пример:
```csharp
bool isReachable = MultiAPI.Internet.ping("example.com");
if (isReachable) Console.WriteLine("Host is reachable.");
else Console.WriteLine("Host is not reachable.");
```

#### Описание:
Проверяет доступность указанного адреса путем отправки запроса на ping

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public static bool ping(string url)
{
    if (string.IsNullOrEmpty(url)) throw new Exception("0x00003"); // Если "URL" пуст, выбрасываем исключение с кодом "0x00003"

    try
    {
        using (var ping = new Ping()) // Создаем экземпляр класса Ping с помощью using, чтобы гарантировать освобождение ресурсов
        {
            var result = ping.Send(url, 1000); // Посылаем пинг на указанный URL с таймаутом 1000 миллисекунд
            return result.Status == IPStatus.Success; // Возвращаем true, если ответ получен успешно, иначе false
        }
    }
    catch { return false; } // Если произошла ошибка во время пинга, возвращаем false
}
```

## Mail.cs - Mail
В этом классе содержутся следущие методы:
```csharp
void send(string fromEmail, string fromName, string toEmail, string subject, string textOrHtml, string smtpServer, int smtpPort, string smtpPasswordMail);
```

### - send
```csharp
void send(string fromEmail, string fromName, string toEmail, string subject, string textOrHtml, string smtpServer, int smtpPort, string smtpPasswordMail);
```

` fromEmail ` - Адрес электронной почты отправителя

` fromName ` - Имя отправителя

` toEmail ` - Адрес электронной почты получателя

` subject ` - Тема письма

` textOrHtml ` - Текст письма или HTML-разметка

` smtpServer ` - SMTP-сервер

` smtpPort ` - Порт SMTP-сервера

` smtpPasswordMail ` - Пароль электронной почты отправителя

#### Пример:
```csharp
MultiAPI.Mail.send("sender@example.com", "Sender Name", "recipient@example.com", "Test Subject", "This is a test email", "smtp.example.com", 587, "password");
```

#### Описание:
Отправляет электронное письмо с указанными параметрами

#### Исключения:
Исключения: ` 0x00003 ` и ` 0x00005 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public static void send(string fromEmail, string fromName, string toEmail, string subject, string textOrHtml, string smtpServer, int smtpPort, string smtpPasswordMail)
{
    if (string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(fromName) || string.IsNullOrEmpty(toEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(textOrHtml) || string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(Convert.ToString(smtpPort)) || string.IsNullOrEmpty(smtpPasswordMail)) throw new Exception("0x00003"); // Если какой-либо параметр пуст, выбрасываем исключение с кодом "0x00003"
    // Проверяем доступность интернета
    if (Internet.TestConnection())
    {
        // Создаем объекты для адресов отправителя и получателя
        MailAddress from = new MailAddress(fromEmail, fromName);
        MailAddress to = new MailAddress(toEmail);
        MailMessage m = new MailMessage(from, to); // Создаем объект сообщения
        m.Subject = subject; // Задаем тему письма
        m.Body = textOrHtml; // Задаем текст письма
        m.IsBodyHtml = true; // Устанавливаем, что тело письма содержит HTML
        SmtpClient smtp = new SmtpClient(smtpServer, smtpPort); // Создаем клиент SMTP
        smtp.Credentials = new NetworkCredential(fromEmail, smtpPasswordMail); // Устанавливаем учетные данные для аутентификации на SMTP-сервере
        smtp.EnableSsl = true; // Включаем SSL для защищенного подключения
        smtp.Send(m); // Отправляем сообщение
    }
    else throw new Exception("0x00005"); // Если нет подключения к интернету, выбрасываем исключение с кодом "0x00005"
}
```

## Music.cs - Music
В этом классе содержутся следущие методы:
```csharp
Music(string pathFile, bool autoStart = false);
void play();
void stop();
void pause();
void setVolume(int volume);
int getVolume();
double getDuration();
void setPosition(double position);
double getPosition();
void updatePath(string pathFile);
string getPath();
void repeat(bool turn);
```

> [!WARNING]
> Такие функции как ` Music(string pathFile, bool autoStart = false); `, ` string getPath(); ` и ` void repeat(bool turn); ` не работают в версиях ниже ` 0.1.2.100 `! При попытке использовании данных функций, пожалуйста, убедитесь, что у вас стоит версия 0.1.2.100 и выше. 

### - Music
```csharp
Music(string pathFile);
```

` pathFile ` - Путь до файла музыки

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
```
```csharp
var music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
```

#### Описание:
Создаёт конструктор для взаимодействия с музыкальным файлом

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public Music(string pathFile, bool autoStart = false)
{
    if (string.IsNullOrEmpty(pathFile)) throw new Exception("0x00003"); // Если "pathFile" пуст, то выдаём исключение "0x00003" 
    musicPlayer.URL = pathFile; // Устанавливаем ссылку для плеера
    musicPlayer.settings.autoStart = autoStart; // Устанавливаем значение авто-старта
}
```

#### - play
```csharp
void play();
```

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.play();
```

#### Описание:
Воспроизводит или продоолжает воспроизведение музыкального файла

#### Код:
```csharp
public void play() => musicPlayer.controls.play(); // Воспроизводим или продолжнаем воспроизведение музыкального файла
```

#### - stop
```csharp
void stop();
```

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.stop();
```

#### Описание:
Останавливает воспроизведение музыкального файла и переводит курсор на начало

#### Код:
```csharp
public void stop() => musicPlayer.controls.stop(); // Останавливаем воспроизведение и переводим курсор на начало
```

### - pause
```csharp
void pause();
```

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.pause();
```

#### Описание:
Приостанавливает возспроизведение музыкального файла. При искользовании ' play(); ' можно продолжить воспроизведение файла

#### Код:
```csharp
public void pause() => musicPlayer.controls.pause(); // Приостанавливаем воспроизведение
```

### - setVolume
```csharp
void setVolume(int volume);
```

` volume ` - Громкость (Максимальное значение: 100, Минимальное значение: 0)

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.setVolume(85);
```

#### Описание:
Устанавливает громкость воспроизведения музыкального файла

#### Исключения:
Исключения: ` 0x00003 `, ` 0x00006 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void setVolume(int volume) 
{ 
    if (volume < 0 || volume > 100) throw new Exception("0x00006"); // Если "volume" меньше "0" или больше "100", то выдаём исключение "0x00006"
    if (string.IsNullOrEmpty(Convert.ToString(volume))) throw new Exception("0x00003"); // Если "volume" пуст, то выдаём исключение "0x00003"
    musicPlayer.settings.volume = volume; // Устанавливаем громкость
}
```

### - getVolume
```csharp
int getVolume();
```

#### Возврат:
Громкость в формате целочисленного типа ` int `. От 0 до 100

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
int volume = music.getVolume();
```
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
Console.WriteLine(music.getVolume());
```

#### Описание:
Получение текущей громкости воспроизводимого музыкального файла

#### Код:
```csharp
public int getVolume() => musicPlayer.settings.volume; // Возвращаем громкость
```

### - getDuration()
```csharp
double getDuration();
```

> [!WARNING]
> В данный момент документации на данный метод отсутствует!

> [!NOTE]
> Т.к. документация на данный метод отсутствует, ниже будет приведён код из файла "Music.cs" где взаимодействуется данный метод. Приносим свои извинения за приченённые неудобства.

```csharp
using System;
using WMPLib;

/* 
  =================- INFO -===================
 * File:         | Music.cs
 * Class:        | Music
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.0.0.0
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | +True
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | Music
    /// <summary>
    /// Действия с музыкальными файлами
    /// </summary>
    public class Music
    {
        #region WindowsMediaPlayer | musicPlayer
        /// <summary>
        /// Музыкальная конструкция
        /// </summary>
        private static WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        #endregion

        #region METHOD-Music | Music
        /// <summary>
        /// Определение конструкции. ( Music nameVar = new Music("C:\\Path\\To\\Music.mp3") )
        /// </summary>
        /// <param name="pathFile">Полный путь до музыкального файла</param>
        public Music(string pathFile)
        {
            if (string.IsNullOrEmpty(pathFile)) throw new Exception("0x00003");
            musicPlayer.URL = pathFile;
        }
        #endregion

        // ...

        #region METHOD-DOUBLE | getDuration
        /// <summary>
        /// Получение длительности музыкального файла из конструкции
        /// </summary>
        /// <returns>Длительность музыкального файла</returns>
        public double getDuration() => musicPlayer.currentMedia.duration;
        #endregion

        // ...
    }
    #endregion
}

```

### - setPosition
```csharp
void setPosition(double position);
```

` position ` - Позиция в музыкальном файле. (Максимальное значение: 1.0, Минимальное значение: 0.0)

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.setPosition(0.7);
```

#### Описание:
Устанавливает позицию курсора в музыкальном файле

#### Исключения:
Исключения: ` 0x00003 `, ` 0x00006 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void setPosition(double position)
{
    if (position < 0.0 || position > 1.0) throw new Exception("0x00006"); // Если "position" меньше "0.0" или больше "1.0", то выдаём исключение "0x00006"
    if (string.IsNullOrEmpty(Convert.ToString(position))) throw new Exception("0x00003"); // Если "position" пуст, то выдаём исключение "0x00003"
    musicPlayer.controls.currentPosition = position; // Устанавливаем позицию
}
```

### - getPosition
```csharp
double getPosition();
```

#### Возврат:
Позиция курсора в музкальном файле

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
double position = music.getPosition();
```
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
Console.WriteLine(music.getPosition());
```

#### Описание:
Возвращает позицию курсора в музыкальном файле в формате ` double ` (От 0.0, до 1.0)

#### Код:
```csharp
public double getPosition() => musicPlayer.controls.currentPosition; // Возвращаем позицию курсора (От 0.0, до 1.0)
```

### - updatePath
```csharp
void updatePath(string pathFile);
```

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.updatePath("C:\\Folder\\testMusicFile2.mp3");
```

#### Описание:
Устанавливает новый музыкальный файл в плеер

#### Исключения:
Исключения: ` 0x00003 `

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#исключения)

#### Код:
```csharp
public void updatePath(string pathFile)
{
    if (string.IsNullOrEmpty(pathFile)) throw new Exception("0x00003"); // Если "pathFile" пуст, то выдаём исключение "0x00003"
    musicPlayer.URL = pathFile; // Устанавливаем новый путь до музыкального файла
}
```

### - getPath
```csharp
string getPath()
```

> [!NOTE]
> Добавлено в версии "0.1.2.96"

#### Возврат: 
Путь до музыкального файла установленного в данный момент

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
string path = music.getPath();
```
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
Console.WriteLine(music.getPath());
```

#### Описание:
Получает и возвращает путь до музыкального файла установленного в данный момент

#### Код:
```csharp
public string getPath() => musicPlayer.URL; // Возвращаем путь до музыкального файла
```

### - repeat
```csharp
void repeat(bool turn);
```

` turn ` - true или false. true - включить повтор, false - выключить повтор

> [!NOTE]
> Добавлено в версии "0.1.2.100"

#### Пример:
```csharp
MultiAPI.Music music = new MultiAPI.Music("C:\\Folder\\testMusicFile.mp3");
music.repeat(true);
```

#### Описание:
Устанавливает значение ` turn ` для повтора песни.

#### Код:
```csharp
public void repeat(bool turn) => musicPlayer.settings.setMode("loop", turn);
```
