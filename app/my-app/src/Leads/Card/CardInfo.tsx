import React from "react";
import { makeStyles, Typography, Box } from "@material-ui/core";
import LocationOnIcon from "@material-ui/icons/PinDropOutlined";
import WorkIcon from "@material-ui/icons/BusinessCenterOutlined";
import CardPrice from "./CardPrice";

interface Props {
  location: string;
  jobCategory: string;
  leadId: number;
  price?: number;
}

const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(2),
  },

  icon: {
    marginRight: theme.spacing(10),
  },
  text: {
    marginRight: theme.spacing(10),
  },
}));

const CardInfo: React.FC<Props> = ({
  location,
  jobCategory,
  leadId,
  price,
}) => {
  const classes = useStyles();

  return (
    <Box className={classes.root}>
      <LocationOnIcon />
      <Typography variant="body1" component="span" className={classes.icon}>
        {location}
      </Typography>
      <WorkIcon />
      <Typography variant="body1" component="span" className={classes.icon}>
        {jobCategory}
      </Typography>
      <Typography variant="body1" component="span" className={classes.text}>
        Job ID: {leadId}
      </Typography>
      {price ? <CardPrice price={price}></CardPrice> : <></>}
    </Box>
  );
};

export default CardInfo;
