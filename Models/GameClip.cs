﻿using System;
using System.Collections.Generic;

namespace DashboardApplication.Models
{
    public class GameClip
    {
        public string GameClipId { get; set; }
        public string State { get; set; }
        public DateTime DatePublished { get; set; }
        public string DateRecorded { get; set; }
        public string LastModified { get; set; }
        public string UserCaption { get; set; }
        public string Type { get; set; }
        public int DurationInSeconds { get; set; }
        public string Scid { get; set; }
        public int TitleId { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }
        public int Views { get; set; }
        public string TitleData { get; set; }
        public string SystemProperties { get; set; }
        public bool SavedByUser { get; set; }
        public string AchievementId { get; set; }
        public string GreatestMomentId { get; set; }
        public List<Thumbnail> Thumbnails { get; set; }
        public List<GameClipUri> GameClipUris { get; set; }
        public object Xuid { get; set; }
        public string ClipName { get; set; }
        public string TitleName { get; set; }
        public string GameClipLocale { get; set; }
        public string ClipContentAttributes { get; set; }
        public string DeviceType { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public int ShareCount { get; set; }
        public int PartialViews { get; set; }
        public string GameClipDetails { get; set; }
    }
}
