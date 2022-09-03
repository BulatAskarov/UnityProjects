using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingHandler : MonoBehaviour
{
    [SerializeField] private GameObject itisPrefab;
    [SerializeField] private GameObject trianglesPrefab;


    private ARTrackedImageManager _imageManager;

    private ARTrackedImageManager ImageManager
    {
        get
        {
            if (_imageManager == null)
            {
                _imageManager = FindObjectOfType<ARTrackedImageManager>();
            }

            return _imageManager;
        }
    }

    private void OnEnable()
    {
        // Subscribes on ImageManager event for any trackables updates
        ImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDisable()
    {
        ImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var arTrackedImage in args.added)
        {
            InstantiateOnAddedImage(arTrackedImage.referenceImage.name, arTrackedImage.transform);
        }
    }

    /// <summary>
    /// Instantiates correct prefab based on tracked image name.
    /// </summary>
    /// <param name="imageName">Tracked image name</param>
    /// <param name="trackedImageParent">Parent transform of tracked image</param>
    private void InstantiateOnAddedImage(string imageName, Transform trackedImageParent)
    {
        if (imageName.Equals("itis"))
        {
            var itis = Instantiate(itisPrefab, trackedImageParent);
        }
        else if (imageName.Equals("triangles"))
        {
            var triangles = Instantiate(trianglesPrefab, trackedImageParent);
        }
    }
}