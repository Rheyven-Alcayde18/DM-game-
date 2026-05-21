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
using System.Media;

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
            { "Lec4",       false  }, //starts unlocked
            { "Lec5",       true  },
            { "Lab1",       true  },
            { "CCSFaculty", true },
            { "Library",    false }, //starts unlocked
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
	public static class User
	{
		public static string name = "";
	}
	public static class SoundManager
	{
		private static SoundPlayer _door = new SoundPlayer("Door Opening.wav");
		private static SoundPlayer _music = new SoundPlayer("BGM2.wav");

	    public static void PlayDoorSound()
	    {
	        _door.Play();
	    }
	    public static void BackGroundMusicPlay()
	    {
	    	_music.Play();
	    }
	    public static void BackGroundMusicStop()
	    {
	    	_music.Stop();
	    }
	}
	public static class DialogueScript
	{
		public static List<DialogueLine> LobbyDialogue()
		{
			return new List<DialogueLine>
            {
                new DialogueLine(
                    User.name,
                    "*yawn* Aughhh... Why does Discrete Mathematics even exist?"
                ),
                new DialogueLine(
                    User.name,
                    "Propositions... truth tables... logical connectives... I swear these things are plotting against me."
                ),
                new DialogueLine(
                    User.name,
                    "Tomorrow is the final exam... and I still feel like I understand absolutely nothing."
                ),
                new DialogueLine(
                    "Narrator",
                    "Books were scattered across the table. His notebook was filled with scratched-out answers and question marks."
                ),
                new DialogueLine(
                    User.name,
                    "If I fail this subject, I'm finished. Okay… one last review. If P then Q…"
                ),
                new DialogueLine(
                    User.name,
                    "…why does this sound like a threat? Maybe just five more minutes… "
                ),
                new DialogueLine(
                    "Narrator",
                    "His eyes grew heavier. The letters on the page began to blur. Without realizing it……. He fell asleep."
                )
            };
		}
		public static List<DialogueLine> CcsFacultyDialogueStart()
        {
            var introLines = new List<DialogueLine>
            {
                new DialogueLine("Prof. Santos",
                    "Ah, good morning! You must be the new student assistant for the CCS department. I have been expecting you."),
                new DialogueLine("Student",
                    "Good morning, Professor Santos! Yes, I am Alex. I was not sure which office to go to — this building is a bit confusing."),
                new DialogueLine("Prof. Santos",
                    "Ha! That happens to everyone. Come in and sit down. We have quite a bit to discuss about your duties this semester."),
                new DialogueLine("Student",
                    "Of course, Professor. I already reviewed the student handbook. Is there anything specific you would like me to prioritize?"),
                new DialogueLine("Prof. Santos",
                    "Sharp thinking — I like that. But before I trust you with lab access, I need to know you are serious. Let me test your logic fundamentals."),
                new DialogueLine("Prof. Santos",
                    "The chalkboard over there has a set of questions. Answer them all correctly and I will personally endorse your clearance. Good luck, Alex."),
            };
            return introLines;
        }
		public static List<DialogueLine> CcsFacultyDialogueEnd()
		{
			var completionLines = new List<DialogueLine>
            {
                new DialogueLine("Prof. Santos",
                    "Remarkable! You have answered every question. I did not expect you to get through that so quickly, Alex."),
                new DialogueLine("Student",
                    "Thank you, Professor! Honestly, the last few were tricky — especially the ones about tautologies and quantifiers."),
                new DialogueLine("Prof. Santos",
                    "Those are precisely the concepts that trip up even second-year students. You clearly studied well."),
                new DialogueLine("Prof. Santos",
                    "I am endorsing your lab access effective immediately. You are cleared for Tuesdays and Thursdays, as we discussed."),
                new DialogueLine("Student",
                    "I really appreciate it, Professor. I will not let you down. I will be early on Tuesday to set everything up."),
                new DialogueLine("Prof. Santos",
                    "I know you will. Welcome to the College of Computer Studies, Alex. A new room has been unlocked for you."),
            };
			return completionLines;
		}
	}
}
