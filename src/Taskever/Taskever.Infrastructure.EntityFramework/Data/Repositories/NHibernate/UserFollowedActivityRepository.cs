using System.Collections.Generic;
using Abp.Domain.Repositories.EntityFramework;
using Taskever.Activities;

namespace Taskever.Infrastructure.EntityFramework.Data.Repositories.NHibernate
{
    public class UserFollowedActivityRepository : TaskeverEfRepositoryBase<UserFollowedActivity, long>, IUserFollowedActivityRepository
    {
        public IList<UserFollowedActivity> Getactivities(int userId, bool? isActor, long beforeId, int maxResultCount)
        {
            return new UserFollowedActivity[0];

            //var queryBuilder = new StringBuilder();
            //queryBuilder.AppendLine("from " + typeof(UserFollowedActivity).FullName + " as ufa");
            //queryBuilder.AppendLine("inner join fetch ufa.Activity as act");
            //queryBuilder.AppendLine("left outer join fetch act.Task as task");
            //queryBuilder.AppendLine("left outer join fetch act.CreatorUser as cusr");
            //queryBuilder.AppendLine("left outer join fetch act.AssignedUser as ausr");
            //queryBuilder.AppendLine("where ufa.User.Id = :userId and ufa.id < :beforeId");

            //if (isActor.HasValue)
            //{
            //    queryBuilder.AppendLine("and ufa.IsActor = :isActor");
            //}

            //queryBuilder.AppendLine("order by ufa.Id desc");

            //var query = Session
            //    .CreateQuery(queryBuilder.ToString())
            //    .SetParameter("userId", userId)
            //    .SetParameter("beforeId", beforeId);

            //if (isActor.HasValue)
            //{
            //    query.SetParameter("isActor", isActor.Value);
            //}

            //return query
            //    .SetMaxResults(maxResultCount)
            //    .List<UserFollowedActivity>();
        }
    }
}