import React from 'react'
import { Notifications, ProfileCard } from './profile-actions-components'

const ProfileActions = () => {
    return (
        <div>
            <div>
                <div>
                    <ProfileCard />
                </div>

                <div>
                    <Notifications />
                </div>
            </div>
        </div>
    )
}

export default ProfileActions
