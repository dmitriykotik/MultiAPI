# MultiAPI - [![GitHub](https://img.shields.io/badge/GitHub-MultiAPI-blue?labelColor=gray&style=flat&link=https://github.com/dmitriykotik/MultiAPI)](https://github.com/dmitriykotik/MultiAPI) [![NuGet](https://img.shields.io/badge/NuGet-v0.1.1-orange?labelColor=gray&style=flat&link=https://www.nuget.org/packages/MultiAPI_Lib)](https://www.nuget.org/packages/MultiAPI_Lib) [![MultiAPI](https://img.shields.io/badge/v0.1.1-not%20stable-red?labelColor=gray&style=flat)]() [![License](https://img.shields.io/badge/License-GPL--3.0-blue?labelColor=gray&style=flat)]()
MultiAPI - Это библиотека и сборка разного ПО (Далее "Библиотека") для разработчиков. Она содержит множество функций чтобы ускорить разработку ПО. Данная библиотека усовершенствованная версия библиотеки MultiLib, MultiAPI подойдёт как начинающим разработчикам, так и профессиональным разработчикам ПО.

**Если вам понравился данный проект, то поставьте пожалуйста звезду на проекте, на [![GitHub](https://img.shields.io/badge/GitHub-MultiAPI-blue?labelColor=gray&style=flat&link=https://github.com/dmitriykotik/MultiAPI)](https://github.com/dmitriykotik/MultiAPI). Спасибо <3**

При возникших вопросах или пожеланиях, вы можете написать на почту multiplayercorporation@gmail.com или создать запрос в **Issues**.

# Документация MultiAPI_Lib
## Введение
Выше в основном описание самой библиотеки. Библиотека и документация в основном нацелена, на начинающих программистов и на облегчение написания кода. Скорее всего найдутся люди с вопросами: "Чем она полезна для начинающих программистов?", "Чем она облегчает написание кода?". Я сам хочу знать ответы на данные вопросы. Библиотека просто существует. Возможно, она найдёт своё применение.

Для работы с библиотекой можно использовать любую среду разработки, но обязательно использовать .net framework версии не меньше 4.7.2!

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
Данный класс можно определить в коде как: MultiAPI.Basic.(METHOD);

В этом классе содержутся следущие методы: 
```csharp
int rnd(int startInt, int endInt);
void terminate(int errorCode);
string getCurrentFolder();
void writeMachine(string text, int countDown = 40, bool writeLine = true);
```

### - rnd
```csharp
int rnd(int startInt, int endInt);
```

` startInt ` - Начальное значение

` endInt ` - Конечное значение

Возврат: Случайное значение от ` startInt ` до ` endInt `


Пример:
```csharp
int random;
random = MultiAPI.Basic.rnd(1,10)
```
```csharp
Console.WriteLine(MultiAPI.Basic.rnd(1, 10))
```
Описание: 

Метод выводит случайное значение от ` startInt ` до ` endInt `. 

### - terminate
```csharp
void terminate(int errorCode);
```

` errorCode ` - Код ошибки

Пример:
```csharp
MultiAPI.Basic.terminate(0);
```
Описание:

Метод завершает работу программы с определённым кодом ошибки

### - getCurrentFolder
```csharp
string getCurrentFolder();
```

Возврат: Путь до папки с программой


Пример:
```csharp
string path;
path = MultiAPI.Basic.getCurrentFolder();
```
```csharp
Console.WriteLine(MultiAPI.Basic.getCurrentFolder);
```
Описание:

Метод возвращает путь к папке с программой

### - writeMachine
```csharp
void writeMachine(string text, int countDown = 40, bool writeLine = true);
```

` text ` - Текст для вывода

` countDown ` - Задержка между символами в миллисекундах (По умолчанию равно 40 миллисекунж)

` writeLine ` - После завершения печати, перевести курсор на новую строку? (По умолчанию равно true (Да))

Пример:
```csharp
MultiAPI.Basic.writeMachine("Hello World!");
```
```csharp
MultiAPI.Basic.writeMachine("Hello World!", 100);
```
```csharp
MultiAPI.Basic.writeMachine("Hello World!", 40, false);
```
Описание: 

Метод печатает в терминал символы из текста с определённой задержкой.

Исключение: 
```csharp
if (countDown == 0) throw new Exception("Промежуток времени равен нулю, что делает её бесполезной");
...
```
Обработка:
```csharp
try
{
    MultiAPI.Basic.writeMachine("Привет, я шишибка :D", 0)
}
catch (Exception ex)
{
    if (ex.Message == "Промежуток времени равен нулю, что делает её бесполезной")
    {
        ...
    }
}
```
> [!INFO]  
> Данное предвиденное исключение возникает, если разработчик в переменной ` countDown ` укажет значение 0. Предвиденное исключение создаётся, потому что, если промежуток времени между символами равен 0, то и смысла в методе нету.

Исключение:
```csharp
...
else if (countDown < 0) throw new Exception("Промежуток времени меньше или равен нулю");
```
Обработка:
```csharp
try
{
    MultiAPI.Basic.writeMachine("Привет, я шишибка :D", -40)
}
catch (Exception ex)
{
    if (ex.Message == "Промежуток времени меньше или равен нулю")
    {
        ...
    }
}
```
> [!INFO]  
> Данное предвиденное исключение возникает, если разработчик в переменной ` countDown ` укажет значение меньше 0. Предвиденное исключение создаётся, потому что, промежуток времени не может быть отрицательным.
