using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalControl
{
    public static class GlobalVar
    {
        /// <summary>
        /// Static value protected by access routine.
        /// </summary>
        static int _globalValue;
        static MLApp.MLApp ml;
        static int lec;
        static int _t;
        static bool x;
        static int num;
        static bool isMprun;
        static bool isnew;
        /// <summary>
        /// Access routine for global variable.
        /// </summary>
        public static int Example
        { get{ return _globalValue;}set{ _globalValue = value;}}
        public static MLApp.MLApp mat
        { get{ return ml;          }set{    ml = value;     }  }
        public static int ti
        { get{ return _t;          }set{    _t = value;     }  }
        public static int Lec
        { get{ return lec;         }set{    lec = value;    }  }
        public static bool chk
        { get{ return x;           }set{    x = value;      }  }
        public static bool Ismatlabrunning
        { get { return isMprun; } set { isMprun = value; } }
        public static bool Isnw
        { get { return isnew; } set { isnew = value; } }
        public static int newb
        { get { return num; } set { num = value; } }
    }
}
