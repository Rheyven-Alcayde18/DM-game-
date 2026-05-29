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
using System.IO;

namespace Laro
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public static class GameState
    {
        // Dictionary to track lock state of each room
        // true = locked, false = unlocked
        public static bool Lec4Completed = false;
        public static bool Lec5Completed = false;
        public static bool Lab1Completed = false;
        public static bool Lec2Completed = false;
        public static bool CCSfCompleted = false;
        
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
	public static class CharacterPortraits
	{
	    public static string Yawn()
	    {
	        if (Gender.value == "Female")
	            return "Assets/FemaleCharacterYawn.png";
	
	        return "Assets/MaleCharacterYawn.png";
	    }
	
	    public static string Frustration()
	    {
	        if (Gender.value == "Female")
	            return "Assets/FCharacterfrustration.png";
	
	        return "Assets/MCharacterfrustration.png";
	    }
	
	    public static string Review()
	    {
	        if (Gender.value == "Female")
	            return "Assets/FcharacterReview.png";
	
	        return "Assets/MCharacterReview.png";
	    }
	    public static string Idle()
	    {
	    	if (Gender.value == "Female")
	    		return "Assets/FemaleIdle.png";
	    	return "Assets/MaleIdle.png";
	    }
	    public static string Shocked()
	    {
	    	if(Gender.value == "Female")
	    		return "Assets/FemaleShocked.png";
	    	return "Assets/MaleShocked.png";
	    }
	    public static string Questioning()
	    {
	    	if(Gender.value == "Female")
	    		return "Assets/FemaleQuestioning.png";
	    	return "Assets/MaleQuestioning.png";
	    }
	    public static string Determination()
	    {
	    	if(Gender.value == "Female")
	    		return "Assets/FemaleDetermination.png";
	    	return "Assets/MaleDetermination.png";
	    }
	}
	public static class Pronouns
	{
	    public static string Subject()
	    {
	        // he / she
	        if (Gender.value == "Female")
	            return "she";
	
	        return "he";
	    }
	
	    public static string Object()
	    {
	        // him / her
	        if (Gender.value == "Female")
	            return "her";
	
	        return "him";
	    }
	
	    public static string Possessive()
	    {
	        // his / her
	        if (Gender.value == "Female")
	            return "her";
	
	        return "his";
	    }
	
	    public static string SubjectCapital()
	    {
	        // He / She
	        if (Gender.value == "Female")
	            return "She";
	
	        return "He";
	    }
	
	    public static string PossessiveCapital()
	    {
	        // His / Her
	        if (Gender.value == "Female")
	            return "Her";
	
	        return "His";
	    }
	}
	public static class User
	{
		public static string name = "";
	}
	public static class AudioManager
	{
		public static bool isMuted = false;
	}
	public static class SoundManager
	{
		private static SoundPlayer _door  = new SoundPlayer(
        Path.Combine(Application.StartupPath, "Door Opening.wav"));
		private static SoundPlayer _buttonAudio  = new SoundPlayer(
        Path.Combine(Application.StartupPath, "ButtonClick.wav"));

	    public static void PlayDoorSound()
	    {
	    	if(!AudioManager.isMuted)
	        _door.Play();
	    }
	    public static void ButtonSound()
	    {
	    	if(!AudioManager.isMuted)
	    		_buttonAudio.Play();
	    }
	}
	public static class MusicManager
	{
		private static SoundPlayer _music = new SoundPlayer(
	    Path.Combine(Application.StartupPath, "BGM2.wav"));
		public static void BackGroundMusicPlay()
	    {
			if(!AudioManager.isMuted)
			{
		    	_music.SoundLocation = Path.Combine(Application.StartupPath, "BGM2.wav");
		    	_music.PlayLooping();
			}
	    }
		
	}
	public class DialogueLine
	{
	    public string Speaker;
	    public string Text;
	    public string Portrait;
	
	    // WITH portrait
	    public DialogueLine(string speaker, string text, string portrait)
	    {
	        Speaker = speaker;
	        Text = text;
	        Portrait = portrait;
	    }
	
	    // WITHOUT portrait
	    public DialogueLine(string speaker, string text)
	    {
	        Speaker = speaker;
	        Text = text;
	        Portrait = "";
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
                    "*yawn* Aughhh... Why does Discrete Mathematics even exist?",CharacterPortraits.Yawn()
                ),
                new DialogueLine(
                    User.name,
                    "Propositions... truth tables... logical connectives... I swear these things are plotting against me.",CharacterPortraits.Frustration()
                ),
                new DialogueLine(
                    User.name,
                    "Tomorrow is the final exam... and I still feel like I understand absolutely nothing.",CharacterPortraits.Frustration()
                ),
                new DialogueLine(
                    "Narrator",
                    "Books were scattered across the table. " + Pronouns.PossessiveCapital() + " notebook was filled with scratched-out answers and question marks."
                ),
                new DialogueLine(
                    User.name,
                    "If I fail this subject, I'm finished. Okay… one last review. If P then Q…",CharacterPortraits.Review()
                ),
                new DialogueLine(
                    User.name,
                    "…why does this sound like a threat? Maybe just five more minutes… ",CharacterPortraits.Review()
                ),
                new DialogueLine(
                    "Narrator",
                    Pronouns.PossessiveCapital() +
                    " eyes grew heavier. The letters on the page began to blur. Without realizing it…… " + Pronouns.Subject() + " fell asleep."
                )
            };
		}
		public static List<DialogueLine> CcsFacultyDialogueStart()
        {
            var introLines = new List<DialogueLine>
            {
                new DialogueLine("Narrator",
                    "The air is still. This is the final room of the Campus of Logic"),
                new DialogueLine(User.name,
            	                 "So this is it.... the final exam.",CharacterPortraits.Idle()),
                new DialogueLine("Narrator",
                    "A shadowy figure appears at the front—the faculty teacher."),
                new DialogueLine("Faculty Teacher",
                    "You have arrived " + User.name +"."),
                new DialogueLine(User.name,
            	                 "Professor?", CharacterPortraits.Shocked()),
                new DialogueLine("Faculty Teacher",
                    "Or perhaps I should no longer call you a student."),
            	new DialogueLine(User.name,
            	                 "What do you mean by that?",CharacterPortraits.Questioning()),
            	new DialogueLine("Faculty Teacher",
                    "This place only understands those who can think beyond confusion. Those who understand logic."),
            	new DialogueLine(User.name,
            	                 "Come on, I just want to go back home!",CharacterPortraits.Frustration()),
            	new DialogueLine("Faculty Teacher",
                    "Yes you will, but only if you pass."),
            	new DialogueLine("Narrator",
                    "Final examination initialized.\nSubject: Discrete Mathematics\nTopics: Propositions, Logical Connectives Truth Tables Quantifiers"),
            	new DialogueLine(User.name,
            	                 "So everything I learned.... leads to this.", CharacterPortraits.Idle()),
            	new DialogueLine("Faculty Teacher",
                    "Knowledge has a price."),
            	new DialogueLine("Faculty Teacher",
                    "Answer truthfully or remain here forever."),
            	new DialogueLine(User.name,
            	                 "I got it already!! I've learned enough! I swear I won't fail this time!",CharacterPortraits.Determination()),
            	new DialogueLine("Faculty Teacher",
                    "Goodluck."),
            };
            return introLines;
        }
		public static List<DialogueLine> CcsFacultyDialogueEnd()
		{
			var completionLines = new List<DialogueLine>
            {
                new DialogueLine("Faculty Teacher",
                    "Many students dislike this subject. But dislike comes from misunderstanding."),
                new DialogueLine(User.name,
				                 "I used to think it was impossible. But now.... it finally makes sense.", CharacterPortraits.Idle()),
                new DialogueLine("Faculty Teacher",
                    "You have passed."),
            };
			return completionLines;
		}
	}
}
