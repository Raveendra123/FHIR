// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MediatR;
using Microsoft.Health.Fhir.Core.Features.Conformance;
using Microsoft.Health.Fhir.Core.Messages.Get;

namespace Microsoft.Health.Fhir.Shared.Core.Features.Conformance
{
    public class GetOperationVersionsHandler : IRequestHandler<GetOperationVersionsRequest, GetOperationVersionsResponse>
    {
        private readonly IConformanceProvider _provider;

        // TODO: IConformance provider seems specific to the metadata endpoint?
        public GetOperationVersionsHandler(IConformanceProvider provider)
        {
            EnsureArg.IsNotNull(provider, nameof(provider));

            _provider = provider;

            // TODO: Remove
            // var p = Parameters
        }

        public async Task<GetOperationVersionsResponse> Handle(GetOperationVersionsRequest message, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(message, nameof(message));

            // TODO: Replace capability statement with list of versions.
            // var response = await _provider.GetOperationVersionsAsync(cancellationToken);
            var response = await _provider.GetCapabilityStatementAsync(cancellationToken);

            return new GetOperationVersionsResponse(response);
        }
    }
}
