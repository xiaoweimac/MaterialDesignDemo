﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace MaterialDesignDemo.Converters
{
    /// <summary>
    /// 处理类型转换
    /// </summary>
    public class DisplayConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (bool.TryParse(value.ToString(),out bool result))
                {
                    if (result)
                    {
                        return Visibility.Visible;
                    }
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
