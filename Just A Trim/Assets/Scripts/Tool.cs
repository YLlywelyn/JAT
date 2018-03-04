﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BJGames.JAT
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Tool : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Tooltip("The type of hair this tool will cut.")]
        public HairTypes hairTypeToCut;

        [Range(0f, 1f)] [Tooltip("The percentage of hair to cut.  If the hair growth is less than this amount, it will all be cut.")]
        public float percentageToCut = 0.25f;

        // The position the object was at when the drag started.
        Vector3 startPosition;

        CanvasGroup group;

        void Start()
        {
            group = GetComponent<CanvasGroup>();

            startPosition = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Started dragging " + this.name);

            group.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            newPosition.z = startPosition.z;

            transform.position = newPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Stopped dragging " + this.name);
            
            transform.position = startPosition;

            group.blocksRaycasts = true;
        }
    }
}