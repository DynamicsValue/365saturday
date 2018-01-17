// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

//<snippetBasicFilteringService>
using System;

using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml.Linq;
using System.Linq;

/// <summary>
/// Sample extension for the CrmSvcUtil.exe tool that generates early-bound
/// classes for custom entities.
/// </summary>
namespace CrmSvcUtilExtensions
{


public sealed class BasicFilteringService : ICodeWriterFilterService
{
    private string FilterXml = "filter.xml";
        private XDocument _xldoc = null;
    public BasicFilteringService(ICodeWriterFilterService defaultService)
    {
        this.DefaultService = defaultService;
        try
        {
            _xldoc = XDocument.Load(FilterXml);
        }
        catch(Exception ex)
        {
            throw new Exception("Could not find filter.xml" + ex.ToString());
        }
    }

    private ICodeWriterFilterService DefaultService { get; set; }

    bool ICodeWriterFilterService.GenerateAttribute(AttributeMetadata attributeMetadata, IServiceProvider services)
    {
        return this.DefaultService.GenerateAttribute(attributeMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateEntity(EntityMetadata entityMetadata, IServiceProvider services)
    {
            var entityName = entityMetadata.LogicalName.ToLower();
            var nodeFound = _xldoc.Root.Elements().Where(node => node.Value.Equals(entityName)).FirstOrDefault();
            if (nodeFound == null)
                return false;

            return this.DefaultService.GenerateEntity(entityMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateOption(OptionMetadata optionMetadata, IServiceProvider services)
    {
        return this.DefaultService.GenerateOption(optionMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateOptionSet(OptionSetMetadataBase optionSetMetadata, IServiceProvider services)
    {
        return this.DefaultService.GenerateOptionSet(optionSetMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateRelationship(RelationshipMetadataBase relationshipMetadata, EntityMetadata otherEntityMetadata,
    IServiceProvider services)
    {
        return this.DefaultService.GenerateRelationship(relationshipMetadata, otherEntityMetadata, services);
    }

    bool ICodeWriterFilterService.GenerateServiceContext(IServiceProvider services)
    {
        return this.DefaultService.GenerateServiceContext(services);
    }
}

}
//</snippetBasicFilteringService>