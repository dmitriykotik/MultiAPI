# MultiAPI - [![GitHub](https://img.shields.io/badge/GitHub-MultiAPI-blue?labelColor=gray&style=flat&link=https://github.com/dmitriykotik/MultiAPI)](https://github.com/dmitriykotik/MultiAPI) [![NuGet](https://img.shields.io/badge/NuGet-v0.1.1-orange?labelColor=gray&style=flat&link=https://www.nuget.org/packages/MultiAPI_Lib)](https://www.nuget.org/packages/MultiAPI_Lib) [![MultiAPI](https://img.shields.io/badge/v0.1.1-not%20stable-red?labelColor=gray&style=flat)]() [![License](https://img.shields.io/badge/License-GPL--3.0-blue?labelColor=gray&style=flat)]()
MultiAPI - Это библиотека и сборка разного ПО (Далее "Библиотека") для разработчиков. Она содержит множество функций чтобы ускорить разработку ПО. Данная библиотека усовершенствованная версия библиотеки MultiLib, MultiAPI подойдёт как начинающим разработчикам, так и профессиональным разработчикам ПО.

**Если вам понравился данный проект, то поставьте пожалуйста звезду на проекте, на [![GitHub](https://img.shields.io/badge/GitHub-MultiAPI-blue?labelColor=gray&style=flat&link=https://github.com/dmitriykotik/MultiAPI)](https://github.com/dmitriykotik/MultiAPI). Спасибо <3**

При возникших вопросах или пожеланиях, вы можете написать на почту multiplayercorporation@gmail.com или создать запрос в **Issues**.

# Документация MultiAPI_Lib
## Введение
Выше в основном описание самой библиотеки. Библиотека и документация в основном нацелена, на начинающих программистов и на облегчение написания кода. Скорее всего найдутся люди с вопросами: "Чем она полезна для начинающих программистов?", "Чем она облегчает написание кода?". Я сам хочу знать ответы на данные вопросы. Библиотека просто существует. Возможно, она найдёт своё применение.

Для работы с библиотекой можно использовать любую среду разработки, но обязательно использовать .net framework версии не меньше 4.7.2!

> [!NOTE]
> В исходных кодах, в документации могут быть комментарии разработчика о том как работает код.

## Быстрый доступ
- [Введение](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#введение)
-- [Импорт библиотеки в проект](https://github.com/dmitriykotik/MultiAPI?tab=readme-ov-file#импорт-библиотеки-в-проект)

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

### Использование командной строки NuGet
1. Откройте ваш проект.
2. Откройте командную строку NuGet (Средства -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов).
3. Введите в консоль следущую команду: ` Install-Package MultiAPI_Lib `, этим вы установите самую последнюю версию. Определённую версию вы можете найти на NuGet [![NuGet](https://img.shields.io/badge/NuGet-v0.1.1-orange?labelColor=gray&style=flat&link=https://www.nuget.org/packages/MultiAPI_Lib)](https://www.nuget.org/packages/MultiAPI_Lib)

### Использование диспетчера пакетов NuGet
1. Откройте ваш проект.
2. Откройте диспетчер пакетов NuGet (Средства -> Диспетчер пакетов NuGet -> Управление пакетами NuGet для решения...).
3. В поисковой строке введите MultiAPI_Lib и найдите пакет с абсолютно таким же названием, а автором ` dmitriykotik_off `.
4. Нажмите на пакет, в правом окне диспетчера выберите проекты в которые вам надо установить библиотеку, версию и нажмите кнопку установить.

### Импорт библиотеки
В проекте испортируйте библиотеку следующим образом:
```csharp
using MultiAPI;
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
```
Возможная обработка (Пример):
```csharp
try
{
    MultiAPI.Basic.writeMachine("Я шишибочка! :D", 0);
}
catch (Exception ex)
{
    if (ex.Message == "0x00001")
    {
        MultiAPI.Basic.terminate(1);
    }
}
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
    │   ├── Music(string pathFile)
    │   ├── void play()
    │   ├── void stop()
    │   ├── void pause()
    │   ├── void setVolume(int volume)
    │   ├── int getVolume()
    │   ├── double getDuration()
    │   ├── void setPosition(double position)
    │   ├── double getPosition()
    │   └── void updatePath(string pathFile)
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

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI/blob/master/README.md#исключения)

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

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI/blob/master/README.md#исключения)

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

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI/blob/master/README.md#исключения)

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

Обработка: [Исключения](https://github.com/dmitriykotik/MultiAPI/blob/master/README.md#исключения)

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
