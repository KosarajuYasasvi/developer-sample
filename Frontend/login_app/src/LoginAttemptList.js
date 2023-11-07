import React, { useState, useMemo } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
    const [filterText, setFilterText] = useState("");

    const filteredList = useMemo(() => {
        if (
            ![null, undefined, ""].includes(filterText.trim()) &&
            Array.isArray(props?.attempts)
        ) {
            return props.attempts.filter(
                (item) =>
                    item?.username?.toLowerCase().indexOf(filterText.toLowerCase()) !== -1
            );
        }
        return Array.isArray(props?.attempts) ? props.attempts : [];

    }, [props?.attempts, filterText]);

    return (
        <div className="Attempt-List-Main">
            <p>Recent activity</p>
            <input
                type="input"
                placeholder="Filter..."
                value={filterText}
                onChange={(e) => setFilterText(e.target.value)}
            />
            <ul className="Attempt-List">
                {filteredList.map((attempt, index) => (
                    <LoginAttempt key={index}>{attempt.username}</LoginAttempt>
                ))}
            </ul>
        </div>
    );
};

export default LoginAttemptList;