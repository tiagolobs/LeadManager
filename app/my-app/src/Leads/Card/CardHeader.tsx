import React from "react";
import { makeStyles, Typography, Box, Avatar } from "@material-ui/core";
import { convertDateToReadableFormat } from "../../Utils/DateUtil";

interface Props {
  name: string;
  date: string;
}

const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(2),
  },

  name: {
    fontWeight: "bold",
  },
  date: {
    marginTop: theme.spacing(1),
  },
  avatar: {
    background: "#FEA04D",
    marginRight: theme.spacing(2),
  },
}));

const CardHeader: React.FC<Props> = ({ name, date }) => {
  const classes = useStyles();

  return (
    <Box className={classes.root}>
      <Avatar className={classes.avatar}>{name[0]}</Avatar>
      <Box>
        <Typography variant="subtitle1" className={classes.name}>
          {name}
        </Typography>
        <Typography variant="caption" className={classes.date}>
          {convertDateToReadableFormat(date)}
        </Typography>
      </Box>
    </Box>
  );
};

export default CardHeader;
