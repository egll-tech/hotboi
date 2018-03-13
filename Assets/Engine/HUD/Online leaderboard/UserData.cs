﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {
    private string username;
    private int highscore;
    private List<int> scores;
    private Dictionary<string, string> achievements;
    private int mostKills;
    private int highestLevelReached;

    public void setUsername(string username) {
        this.username = username;
    }
    public string getUsername() {
        return this.username;
    }
    public void setHighscore(int highscore) {
        this.highscore = highscore;
    }
    public int getHighscore() {
        return this.highscore;
    }
    public void addScore(int score) {
        this.scores.Add(score);
    }
    public void addAchievement(string title, string description) {
        this.achievements.Add(title, description);
    }
    public Dictionary<string, string> getAchievements() {
        return achievements;
    }
    public void setAsMostKillsIfNewMax(int kills) {
        if (kills > this.mostKills) {
            this.mostKills = kills;
        }
    }
    public int getMostKills() {
        return this.mostKills;
    }
    public void setHighestLevelReachedIfNewMax(int levelReached) {
        if (levelReached > this.highestLevelReached) {
            this.highestLevelReached = levelReached;
        }
    }
    public int getHighestLevelReached() {
        return this.highestLevelReached;
    }
}
