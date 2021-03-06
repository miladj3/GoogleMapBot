﻿using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GoogleMapBot.Models
{
      public class KeyBord
    {
          public KeyboardButton[][] GetReplyKeyboardMarkup(string[] stringArray, int ColInRow,
           int btnType, KeyboardButton[] extrabtn)
        {
            int col = ColInRow;
            int row = stringArray.Length / col;
            row = (stringArray.Length % col) != 0 ? ++row : row;

            col = col > stringArray.Length ? stringArray.Length : col;
            var keyboardInline = new KeyboardButton[row + (extrabtn != null ? 1 : 0)][];

            int IndexstringArray = 0;
            int btnarrcur = 0;
            for (var j = 0; j < row; j++)
            {
                col = ((j + 1) == row && (stringArray.Length % col != 0)) ? (col - 1) : col;
                var keyboardButtons = new KeyboardButton[col];
                for (var i = 0; i < col; i++)
                {
                    keyboardButtons[i] = new KeyboardButton()

                    {
                        Text = stringArray[IndexstringArray],
                    };

                    if (stringArray[IndexstringArray].Contains("@"))
                    {
                        keyboardButtons[i].Text = stringArray[IndexstringArray].Replace("@", string.Empty);
                        keyboardButtons[i].RequestContact = true;
                    }
                    if (stringArray[IndexstringArray].Contains("%"))
                    {
                        keyboardButtons[i].Text = stringArray[IndexstringArray].Replace("%", string.Empty);
                        keyboardButtons[i].RequestLocation = true;
                    }
                    ++btnarrcur;
                    IndexstringArray++;
                }
                keyboardInline[j] = keyboardButtons;
            }

            if (extrabtn != null)
                keyboardInline[row] = extrabtn;
            return keyboardInline;
        }

          public InlineKeyboardButton[][] GetInlineKeyboard(string[] stringArray, string[] stringValue, int ColInRow,
            int btnType, InlineKeyboardButton[] extrabtn, string Link = "")
        {
            //btnType ==> 1: URL  2:CallBack
            int col = ColInRow;
            int row = stringArray.Length / col;
            row = (stringArray.Length % col) != 0 ? ++row : row;

            col = col > stringArray.Length ? stringArray.Length : col;
            var keyboardInline = new InlineKeyboardButton[row + (extrabtn != null ? 1 : 0)][];

            int IndexstringArray = 0;
            int btnarrcur = 0;
            for (var j = 0; j < row; j++)
            {
                col = ((j + 1) == row && (stringArray.Length % col != 0)) ? (col - 1) : col;
                var keyboardButtons = new InlineKeyboardButton[col];
                for (var i = 0; i < col; i++)
                {
                    keyboardButtons[i] = new InlineKeyboardButton
                    {
                        Text = stringArray[IndexstringArray],
                        CallbackData = stringValue[IndexstringArray],
                    };
                    if (Link != "")
                        keyboardButtons[i].Url = Link;
                    ++btnarrcur;
                    IndexstringArray++;
                }
                keyboardInline[j] = keyboardButtons;
            }
            if (extrabtn != null)
                keyboardInline[row] = extrabtn;
            return keyboardInline;
        }

     public   ReplyKeyboardMarkup KeyBordMnu(string FirstB)
        {
            ReplyKeyboardMarkup mainMenu = new ReplyKeyboardMarkup();
            mainMenu.ResizeKeyboard = true;
            mainMenu.Selective = true;
            mainMenu.Keyboard =
               new KeyboardButton[][]
               {   new KeyboardButton[]
        {

             new KeyboardButton(FirstB),


        },

          new KeyboardButton[]
        {
            new KeyboardButton("🌎   ورد به سایت"),
            new KeyboardButton("📱   درباره ما "),


        },

            new KeyboardButton[]
        {
            new KeyboardButton("من افلاین هستم  🔴"),

        },
               };
            return mainMenu;
        }
    }

     
} 