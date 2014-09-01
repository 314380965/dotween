﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/10 19:24
// 
// License Copyright (c) Daniele Giardini.
// This work is subject to the terms at http://dotween.demigiant.com/license.php

using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Core.DefaultPlugins.Options;

#pragma warning disable 1591
namespace DG.Tweening.Plugins.Core.DefaultPlugins
{
    public class UintPlugin : ABSTweenPlugin<uint, uint, NoOptions>
    {
        public override uint ConvertT1toT2(TweenerCore<uint, uint, NoOptions> t, uint value)
        {
            return value;
        }

        public override void SetRelativeEndValue(TweenerCore<uint, uint, NoOptions> t)
        {
            t.endValue += t.startValue;
        }

        public override void SetChangeValue(TweenerCore<uint, uint, NoOptions> t)
        {
            t.changeValue = t.endValue - t.startValue;
        }

        public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, uint changeValue)
        {
            float res = changeValue / unitsXSecond;
            if (res < 0) res = -res;
            return res;
        }

        public override uint Evaluate(NoOptions options, Tween t, bool isRelative, DOGetter<uint> getter, float elapsed, uint startValue, uint changeValue, float duration)
        {
            if (t.loopType == LoopType.Incremental) startValue += (uint)(changeValue * (t.isComplete ? t.completedLoops - 1 : t.completedLoops));

            return (uint)Math.Round(EaseManager.Evaluate(t, elapsed, startValue, changeValue, duration, t.easeOvershootOrAmplitude, t.easePeriod));
        }
    }
}