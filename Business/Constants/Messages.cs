﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç ismi en az 2 karakter olmalıdır";
        public static string CarPriceInvalid = "Aracın günlük fiyatı 0'dan büyük olmalıdır.";
        public static string CarBrandInvalid = "Lütfen geçerli bir marka giriniz";
        public static string CarBrandAdded = "Marka eklendi";
        public static string CarColorInvalid = "Lütfen geçerli bir renk giriniz";
        public static string CarColorAdded = "Renk eklendi";
        public static string MaintenanceTime = "Sistem bakımda daha sonra tekrar deneyiniz";
        public static string CarsListed = "Araçlar listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserDetailsListed = "Kullanıcı detayları listelendi";
        public static string UserGet = "Kullanıcı getirildi";
        public static string CostumerAdded = "Müşteri eklendi";
        internal static string AccessTokenCreated;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string? AuthorizationDenied;
        internal static string UserRegistered;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
    }
}
