﻿#region

using Microsoft.Extensions.DependencyInjection;
using PhotoContest.Implementation.Ado.DataRecords;
using PhotoContest.Implementation.Ado.Providers;
using PhotoContest.Implementation.Cache;
using PhotoContest.Implementation.Service;
using PhotoContest.Implementation.Service.Files;
using PhotoContest.Services;

#endregion

namespace PhotoContest.Implementation;

/// <summary>
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// </summary>
    /// <param name="services"></param>
    /// <param name="isDev"></param>
    public static void ConfigureServices(this IServiceCollection services, bool isDev)
    {
        services.AddSingleton<IProvider<Submission>, SubmissionProvider>();
        services.AddSingleton<IProvider<UserInfo>, UserInfoProvider>();
        services.AddSingleton<IProvider<VoteInfo>, VoteInfoProvider>();
        services.AddSingleton<IProvider<Contest>, ContestProvider>();
        services.AddSingleton<IProvider<ScoreInfo>, ScoreInfoProvider>();
        services.AddSingleton<IProvider<FileInfo>, FileInfoProvider>();

        if (isDev)
            services.AddSingleton<IFileProvider, SystemFileProvider>();
        else
            services.AddSingleton<IFileProvider, AzureBlobProvider>();

        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IDataStore, CachedDataStore>();
        services.AddSingleton<IContestManagementService, ContestManagementService>();
    }
}