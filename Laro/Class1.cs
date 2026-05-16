/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 5/15/2026
 * Time: 9:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laro
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public static class GameState
    {
        // Dictionary to track lock state of each room
        // true = locked, false = unlocked
        public static Dictionary<string, bool> RoomLocks = new Dictionary<string, bool>()
        {
            { "Lec2",       true  },
            { "Lec4",       false  },
            { "Lec5",       true  },
            { "Lab1",       true  },
            { "CCSFaculty", false }, // example: starts unlocked
            { "Library",    false },
        };

        // Helper methods
        public static bool IsLocked(string roomName)
        {
            return RoomLocks.ContainsKey(roomName) && RoomLocks[roomName];
        }

        public static void UnlockRoom(string roomName)
        {
            if (RoomLocks.ContainsKey(roomName))
                RoomLocks[roomName] = false;
        }

        public static void LockRoom(string roomName)
        {
            if (RoomLocks.ContainsKey(roomName))
                RoomLocks[roomName] = true;
        }
    }
	public static class Gender
	{
		public static string value = "";
	}
}
