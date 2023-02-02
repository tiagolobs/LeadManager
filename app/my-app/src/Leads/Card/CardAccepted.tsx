import { Box, Divider, makeStyles, Paper, Typography } from "@material-ui/core";
import React from "react";
import CardContact from "./CardContact";
import CardHeader from "./CardHeader";
import CardInfo from "./CardInfo";

const useStyles = makeStyles((theme) => ({
  paper: {
    background: "white",
    padding: "10px",
    margin: "30px 0",
  },
  text: {
    padding: theme.spacing(2),
  },
}));

interface Props {
  name: string;
  date: string;
  location: string;
  jobCategory: string;
  leadId: number;
  description: string;
  price: number;
  email: string;
  phoneNumber: string;
}

const CardAccepted: React.FC<Props> = ({
  name,
  date,
  location,
  jobCategory,
  leadId,
  description,
  price,
  email,
  phoneNumber,
}) => {
  const classes = useStyles();
  return (
    <Paper className={classes.paper}>
      <CardHeader name={name} date={date}></CardHeader>
      <Divider />
      <CardInfo
        location={location}
        jobCategory={jobCategory}
        leadId={leadId}
        price={price}
      ></CardInfo>

      <Divider />
      <CardContact phoneNumber={phoneNumber} email={email}></CardContact>
      <Box className={classes.text}>
        <Typography variant="body2">{description}</Typography>
      </Box>
    </Paper>
  );
};

export default CardAccepted;
