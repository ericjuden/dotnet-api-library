using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Users
{
    public class UserGroupRequest : RequestBaseObject
    {
        /// <summary>
        /// The unique numeric identifier of the user group
        /// </summary>
        [RequiredField(RequestTypes.Update)]
        [ResponseProperty("Id")]
        public int Id { get; set; }

        /// <summary>
        /// The title of the user group. 
        /// </summary>
        [RequiredField]
        [ResponseProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// The type of user group ('guest' or 'registered')
        /// </summary>
        [RequiredField(RequestTypes.Create)]
        [ResponseProperty("GroupType")]
        public UserGroupType GroupType { get; set; }

        public static UserGroupRequest FromResponseData(UserGroup responseData)
        {
            return UserGroupRequest.FromResponseType<UserGroup, UserGroupRequest>(responseData);
        }

        public static UserGroup ToResponseData(UserGroupRequest requestData)
        {
            return UserGroupRequest.ToResponseType<UserGroupRequest, UserGroup>(requestData);
        }
    }
}
