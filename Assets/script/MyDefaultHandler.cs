using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyDefaultHandler : DefaultTrackableEventHandler
{
    public delegate void OnTrackerFound(Transform transforme); //retourn le Transforme 

    private OnTrackerFound m_TrackerFoundislistners;

    private OnTrackerFound m_TrackerLostislistners;




    public void AddOnTrackerFound(OnTrackerFound _newListner)
    {
        m_TrackerFoundislistners += _newListner;

      
    }

    public void RemoveOnTrackerFound(OnTrackerFound _oldListner)
    {
        m_TrackerFoundislistners -= _oldListner;

    }

    public void AddOnTrackerLost(OnTrackerFound _newListner)
    {
        m_TrackerLostislistners += _newListner;

    }

    public void RemoveOnTrackerLost(OnTrackerFound _oldListner)
    {
        m_TrackerLostislistners -= _oldListner;

    }


    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Debug.Log("Trackable new, found");

        m_TrackerFoundislistners.Invoke(transform);


    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Debug.Log("Trackable new, Lost");

        if (m_TrackerLostislistners != null)
        {
            m_TrackerLostislistners.Invoke(transform);
        }

    }




}
