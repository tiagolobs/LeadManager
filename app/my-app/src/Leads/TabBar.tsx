import { makeStyles, Tab, Tabs, Theme } from "@material-ui/core";
import React, { useState } from "react";
import LeadAcceptedList from "./LeadAcceptedList";
import LeadList from "./LeadList";

const useStyles = makeStyles((theme: Theme) => ({
  root: {
    padding: "10px ",
    flexGrow: 1,
    background: "#EEEEEE",
  },
  tab: {
    textTransform: "none",
    fontSize: theme.spacing(3),
  },
}));

const TabComponent: React.FC = () => {
  const classes = useStyles();
  const [value, setValue] = useState(0);

  const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setValue(newValue);
  };

  return (
    <div className={classes.root}>
      <Tabs
        style={{
          background: "white",
          display: "flex",
          justifyContent: "center",
        }}
        value={value}
        onChange={handleChange}
        variant="fullWidth"
      >
        <Tab className={classes.tab} label="Invited" />
        <Tab className={classes.tab} label="Accepted" />
      </Tabs>
      {value === 0 ? <LeadList /> : <LeadAcceptedList />}
    </div>
  );
};

export default TabComponent;
