﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;

namespace QuantConnect.Optimizer
{
    /// <summary>
    /// Defines the optimization settings, direction, solution and exit, i.e. optimization strategy
    /// </summary>
    public interface IOptimizationStrategy
    {
        /// <summary>
        /// Fires when new parameter set is retrieved
        /// </summary>
        event EventHandler NewParameterSet;

        /// <summary>
        /// Generates parameters for given settings of optimization parameters
        /// </summary>
        IOptimizationParameterSetGenerator ParameterSetGenerator { get; }

        /// <summary>
        /// The way to compare and find the better point
        /// </summary>
        Extremum Extremum { get; }

        /// <summary>
        /// Best found solution, its value and parameter set
        /// </summary>
        OptimizationResult Solution { get; }

        /// <summary>
        /// Initializes the strategy using generator, extremum settings and optimization parameters
        /// </summary>
        /// <param name="parameterSetGetGenerator">Parameter set generator</param>
        /// <param name="extremum">Maximize or Minimize the target value</param>
        /// <param name="parameters">Optimization parameters</param>
        void Initialize(IOptimizationParameterSetGenerator parameterSetGetGenerator, Extremum extremum, HashSet<OptimizationParameter> parameters);
        
        /// <summary>
        /// Callback when lean compute job completed.
        /// </summary>
        /// <param name="result">Lean compute job result and corresponding parameter set</param>
        void PushNewResults(OptimizationResult result);
    }
}
