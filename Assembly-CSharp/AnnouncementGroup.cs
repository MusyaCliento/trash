using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Announcement Group", menuName = "White Knuckle/Announcements/Announcement Group")]
public class AnnouncementGroup : ScriptableObject
{
	public List<AnnouncementController.AnnouncementCategory> announcements;
}
