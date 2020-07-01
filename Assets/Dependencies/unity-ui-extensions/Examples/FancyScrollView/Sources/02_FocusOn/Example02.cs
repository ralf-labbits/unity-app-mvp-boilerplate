﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.UI.Extensions.Examples.FancyScrollViewExample02
{
    public class Example02 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;
        [SerializeField] Button prevCellButton = default;
        [SerializeField] Button nextCellButton = default;
        [SerializeField] Text selectedItemInfo = default;

        void Start()
        {
            prevCellButton.onClick.AddListener(scrollView.SelectPrevCell);
            nextCellButton.onClick.AddListener(scrollView.SelectNextCell);
            scrollView.OnSelectionChanged(OnSelectionChanged);

            var items = Enumerable.Range(0, 20)
                .Select(i => new ItemData($"Cell {i}"))
                .ToArray();

            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
        }

        void OnSelectionChanged(int index)
        {
            selectedItemInfo.text = $"Selected item info: index {index}";
        }
    }
}
