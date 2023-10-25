using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //About Auth
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string PasswordUpdated = "Şifre Güncellendi";
        public static string PasswordUpdateError = "Şifre Güncellenemedi";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Bu Kullanıcı Zaten Mevcut";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserRegisterError = "Kayıt Başarısız";
        public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu";

        //Examples
        public static string ExampleSuccess = "Başarılı";
        public static string ExampleError = "Hata";
    }
}
