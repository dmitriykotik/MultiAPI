using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Terminal.Gui;

namespace MultiAPI_Terminal
{
    public static class Permission
    {
        public static bool DangerPermission(string app, string[] permissions)
        {
            string perm;
            if (permissions.Length > 1) perm = string.Join(", ", permissions);
            else perm = string.Join("", permissions);
            Application.Init();
            var mess = MessageBox.ErrorQuery(app, $"Приложение {app} запрашивает следующие права: {perm}. Обратите внимание, что предоставлять данные права крайне опасно! Разрешить доступ?", "Нет", "Да");
            Application.Shutdown();
            if (mess == 0) return false;
            else return true;
        }

        public static bool StandartPermission(string app, string[] permissions)
        {
            string perm;
            if (permissions.Length > 1) perm = string.Join(", ", permissions);
            else perm = string.Join("", permissions);
            Application.Init();
            var mess = MessageBox.Query(app, $"Приложение {app} запрашивает следующие права: {perm}. Разрешить доступ?", "Нет", "Да");
            Application.Shutdown();
            if (mess == 0) return false;
            else return true;
        }

        public static bool DangerAction(string app, string[] action)
        {
            string act;
            if (action.Length > 1) act = string.Join(", ", action);
            else act = string.Join("", action);
            Application.Init();
            var mess = MessageBox.ErrorQuery(app, $"Приложение {app} запрашивает права на выполнение следующего действия: {act}. Обратите внимание, что предоставлять данные права на это(-и) действие(-я) крайне опасно! Разрешить действие?", "Нет", "Да");
            Application.Shutdown();
            if (mess == 0) return false;
            else return true;
        }

        public static bool StandartAction(string app, string[] action)
        {
            string act;
            if (action.Length > 1) act = string.Join(", ", action);
            else act = string.Join("", action);
            Application.Init();
            var mess = MessageBox.Query(app, $"Приложение {app} запрашивает права на выполнение следующего действия: {act}. Разрешить действие?", "Нет", "Да");
            Application.Shutdown();
            if (mess == 0) return false;
            else return true;
        }
    }
    
}
