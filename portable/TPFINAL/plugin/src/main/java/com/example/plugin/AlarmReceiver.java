package com.example.plugin;

import android.app.AlarmManager;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

public class AlarmReceiver extends BroadcastReceiver {

    public static final String TAG = "AlarmReceiver";
    private AlarmManager alarmMgr;
    @Override
    public void onReceive(Context context, Intent intent) {

        int id = intent.getIntExtra("ID", -1);

        Log.d(TAG, "onReceive(" + context + ", " + intent + ")");
        Log.d(TAG, "UnityPlayer.currentActivity=" + UnityPlayer.currentActivity);
        Log.d(TAG, "message=" + intent.getStringExtra("MESSAGE"));
        Log.d(TAG, "id=" + id);

        Intent unityIntent = new Intent(context, UnityPlayerActivity.class);
        unityIntent.putExtra("ID", id);
        PendingIntent pendingIntent = PendingIntent.getActivity(context, id, unityIntent, PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);

        Notification.Builder builder = new Notification.Builder(context);
        builder.setSmallIcon(android.R.drawable.ic_dialog_alert)
                .setContentTitle(intent.getStringExtra("MESSAGE"))
                .setContentIntent(pendingIntent)
                .setAutoCancel(true);

        NotificationManager notificationManager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.notify(id, builder.build());


    }
}
