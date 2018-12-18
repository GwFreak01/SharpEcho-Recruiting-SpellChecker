﻿using System;
using System.Net;
using SharpEcho.Recruiting.SpellChecker.Contracts;

namespace SharpEcho.Recruiting.SpellChecker.Core
{
    /// <summary>
    /// This is a dictionary based spell checker that uses dictionary.com to determine if
    /// a word is spelled correctly
    /// 
    /// The URL to do this looks like this: http://dictionary.reference.com/browse/<word>
    /// where <word> is the word to be checked
    /// 
    /// Example: http://dictionary.reference.com/browse/SharpEcho would lookup the word SharpEcho
    /// 
    /// We look for something in the response that gives us a clear indication whether the
    /// word is spelled correctly or not
    /// </summary>
    public class DictionaryDotComSpellChecker : ISpellChecker
    {
        public bool Check(string word)
        {
            string apiEndpoint = "http://dictionary.reference.com/browse/";
            string uri = apiEndpoint + word;
            
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Close();
                    return true;
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
