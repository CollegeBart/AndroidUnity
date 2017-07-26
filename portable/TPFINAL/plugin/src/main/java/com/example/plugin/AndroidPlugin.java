package com.example.plugin;


import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.SystemClock;


import com.example.plugin.AlarmReceiver;
import com.unity3d.player.UnityPlayer;

public class AndroidPlugin {


    public static void ScheduleNotification(long delay, String message, int id) {

        Intent intent = new Intent(UnityPlayer.currentActivity, AlarmReceiver.class);
        intent.putExtra("ID", id);
        intent.putExtra("MESSAGE", message);
        PendingIntent pendingIntent = PendingIntent.getBroadcast(UnityPlayer.currentActivity,
                id, intent, PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);
        AlarmManager alarmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        alarmManager.setExact(AlarmManager.ELAPSED_REALTIME,
                SystemClock.elapsedRealtime() + delay, pendingIntent);


    }

    public static void ScheduleEnergyFull(long delay, String message, int id)
    {
        Intent intent = new Intent(UnityPlayer.currentActivity, AlarmReceiver.class);
        intent.putExtra("ID", id);
        intent.putExtra("MESSAGE", message);
        PendingIntent penInten = PendingIntent.getBroadcast(UnityPlayer.currentActivity, id, intent, PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);
        AlarmManager alrmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        alrmManager.setExact(AlarmManager.ELAPSED_REALTIME, SystemClock.elapsedRealtime() + delay, penInten);
    }

    public static int GetExtraID() {
        return UnityPlayer.currentActivity.getIntent().getIntExtra("ID", -1);
    }



}
